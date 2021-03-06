﻿using System;
using System.Collections.Generic;
using System.Linq;
using StorageArea.Model;

namespace Storage
{
    public class General
    {

        public StorageArea.StorageAreaClient connection = null;
        public StorageArea.StorageAreaBuilder builder = null;

        public string config = "";
        // 端口 列 行 列间距 行间距
        private int Port = 0;
        public string columns = "";
        public string rows = "";
        private string columnspace = "";
        private string rowsspace = "";

        public int StorageAreaCount = 0;
        private string StorageAreaspacing = "";

        //1 新立库 2 双身为 3 配餐  4老库 5 窄巷道
        public int StorageType = 0;
        public void Initialize(string config)
        {
            try
            {
                if (config == "StorageArea_new")
                {
                    StorageType = 1;
                }
                else if (config == "StorageArea_new_double")
                {
                    StorageType = 2;
                }
                else if (config == "StorageArea_pcc")
                {
                    StorageType = 3;
                }
                getConfigData(config);
                connection = new StorageArea.StorageAreaClient();
                connection.DataChanged += dataChanged;
                connection.PlaceSelected += placeSelected;
                connection.Connect("localhost", Port);
                builder = new StorageArea.StorageAreaBuilder(connection);
                for (int i = 0; i < StorageAreaCount; i++)
                {
                    string Zoffset = StorageAreaspacing.Split(',')[i];
                    repl(connection, builder, "Rack " + columns + " " + rows + " " + Zoffset + " " + rowsspace + " " + columnspace + "");
                }
                repl(connection, builder, "Build");
            }
            catch (Exception ex)
            {
                throw (ex);
               // return;
            }
        }

        public void Change(uint StorageArea, uint columns, uint rows, uint type, uint id)
        {
            try
            {
                repl(connection, builder, "Change (" + columns.ToString() + "," + rows.ToString() + "," + StorageArea.ToString() + ") " + type.ToString() + " " + id.ToString() + "");
            }catch(Exception ex)
            {
            
            }
        }

        public void FullAll()
        {
            uint xx = 0;
            for (int i = 0; i < StorageAreaCount; i++)
            {
                for (int x = 0; x < int.Parse(columns); x++)
                {
                    for (int y = 0; y < int.Parse(rows); y++)
                    {
                        xx++;
                        Change((uint)i, (uint)x, (uint)y, (uint)StorageType * 10 + 1, xx);
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
        }

        private void repl(StorageArea.StorageAreaClient client, StorageArea.StorageAreaBuilder builder, string readline)
        {
            try
            {
                var line = readline;
                var splittedLine = line.Split(' ');
                switch (splittedLine[0])
                {
                    case "Disconnect":
                        client.Disconnect();
                        return;
                    case "Change":
                        var coordinateString = splittedLine[1];
                        coordinateString = coordinateString.Trim('(', ')');
                        var coordinates = coordinateString.Split(',');
                        var column = ushort.Parse(coordinates[0]);
                        var row = ushort.Parse(coordinates[1]);
                        var rack = ushort.Parse(coordinates[2]);
                        //var data = ulong.Parse(splittedLine[2]);
                        var type = uint.Parse(splittedLine[2]);
                        var id = uint.Parse(splittedLine[3]);
                        // change data
                        client.ChangeData(Tuple.Create(column, row, rack), BitConverter.GetBytes(id).Concat(BitConverter.GetBytes(type)));
                        // alternative
                        client.GetPlace(column, row, rack).SetData(type, id);
                        break;
                    case "Rack":
                        var columns = ushort.Parse(splittedLine[1]);
                        var rows = ushort.Parse(splittedLine[2]);
                        var position = float.Parse(splittedLine[3]);
                        var layerSpace = float.Parse(splittedLine[4]);
                        var columnSpace = float.Parse(splittedLine[5]);
                        // add a rack
                        builder.WithRack(columns, rows, position, layerSpace, columnSpace);
                        break;
                    case "Build":
                        builder.Build();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        // examplary DataChanged-handler
        private static void dataChanged(IEnumerable<StorageArea.Model.Place> changedPlaces)
        {
            foreach (var place in changedPlaces)
            {
                //Console.WriteLine(place.ToString());
            }
            //Console.Write("> ");
        }

        private static void placeSelected(StorageArea.Model.Place selectedPlace)
        {
            var placeData = selectedPlace.GetData();
            //Console.WriteLine(string.Format("Place '({0},{1},{2})' selected! PalletType={3} and PalletId={4}", selectedPlace.Column, selectedPlace.Row, selectedPlace.Rack, placeData.Item1, placeData.Item2));
            //Console.Write("> ");
        }

        private void getConfigData(string str)
        {
            try
            {
                string config = System.Configuration.ConfigurationManager.AppSettings[str].ToString();
                string[] arr = config.Split('*');
                if (arr.Length == 7)
                {
                    Port = int.Parse(arr[0].ToString());
                    columns = arr[1].ToString();
                    rows = arr[2].ToString();
                    columnspace = arr[3].ToString();
                    rowsspace = arr[4].ToString();
                    StorageAreaCount = int.Parse(arr[5].ToString());
                    StorageAreaspacing = arr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
                //return;
            }
        }
    }
}

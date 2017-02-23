using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public static class ExtendedPlace
    {

        /// <summary>
        /// Use this method the change the data of the given place.
        /// </summary>
        /// <param name="place">The place object to change.</param>
        /// <param name="palletType">The type of the pallet.</param>
        /// <param name="palletId">The id of the pallet.</param>
        public static void SetData(this StorageArea.Model.Place place, uint palletType, uint palletId)
        {
            place.Data = BitConverter.GetBytes(palletId).Concat(BitConverter.GetBytes(palletType)).ToArray();
        }

        /// <summary>
        /// Use this method get the data stored for the given place as tuple.
        /// </summary>
        /// <param name="place">The place-object to get the data for.</param>
        /// <returns>A tuple containing the palledType as Item1 and the palledId as Item2.</returns>
        public static Tuple<uint, uint> GetData(this StorageArea.Model.Place place)
        {
            var palletType = BitConverter.ToUInt32(place.Data, 4);
            var palletId = BitConverter.ToUInt32(place.Data, 0);
            return Tuple.Create(palletType, palletId);
        }

    }
}

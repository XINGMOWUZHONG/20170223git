namespace PccNew
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("悬挂线");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("配餐车");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("配餐区", new System.Windows.Forms.TreeNode[] {
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("1号车");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("2号车");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("3号车");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("4号车");
            System.Windows.Forms.TreeNode treeNode50 = new System.Windows.Forms.TreeNode("5号车");
            System.Windows.Forms.TreeNode treeNode51 = new System.Windows.Forms.TreeNode("AGV小车", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48,
            treeNode49,
            treeNode50});
            System.Windows.Forms.TreeNode treeNode52 = new System.Windows.Forms.TreeNode("1号堆垛机");
            System.Windows.Forms.TreeNode treeNode53 = new System.Windows.Forms.TreeNode("2号堆垛机");
            System.Windows.Forms.TreeNode treeNode54 = new System.Windows.Forms.TreeNode("3号堆垛机");
            System.Windows.Forms.TreeNode treeNode55 = new System.Windows.Forms.TreeNode("入库穿梭车");
            System.Windows.Forms.TreeNode treeNode56 = new System.Windows.Forms.TreeNode("出库穿梭车");
            System.Windows.Forms.TreeNode treeNode57 = new System.Windows.Forms.TreeNode("采购库", new System.Windows.Forms.TreeNode[] {
            treeNode52,
            treeNode53,
            treeNode54,
            treeNode55,
            treeNode56});
            System.Windows.Forms.TreeNode treeNode58 = new System.Windows.Forms.TreeNode("物流设备", new System.Windows.Forms.TreeNode[] {
            treeNode43,
            treeNode45,
            treeNode51,
            treeNode57});
            System.Windows.Forms.TreeNode treeNode59 = new System.Windows.Forms.TreeNode("马扎克");
            System.Windows.Forms.TreeNode treeNode60 = new System.Windows.Forms.TreeNode("柔性制造");
            System.Windows.Forms.TreeNode treeNode61 = new System.Windows.Forms.TreeNode("MF制造");
            System.Windows.Forms.TreeNode treeNode62 = new System.Windows.Forms.TreeNode("轴杆加工");
            System.Windows.Forms.TreeNode treeNode63 = new System.Windows.Forms.TreeNode("机床设备", new System.Windows.Forms.TreeNode[] {
            treeNode59,
            treeNode60,
            treeNode61,
            treeNode62});
            this.panel2 = new System.Windows.Forms.Panel();
            this.bt_hideshow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.bt_video_1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_search = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_goon = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.bt_pause = new System.Windows.Forms.Button();
            this.bt_play = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabpanel = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bt_view_reset = new System.Windows.Forms.Button();
            this.bt_view_before = new System.Windows.Forms.Button();
            this.bt_view_left = new System.Windows.Forms.Button();
            this.bt_view_down = new System.Windows.Forms.Button();
            this.bt_view_after = new System.Windows.Forms.Button();
            this.bt_view_right = new System.Windows.Forms.Button();
            this.bt_view_up = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.bt_pos_right = new System.Windows.Forms.Button();
            this.bt_pos_down = new System.Windows.Forms.Button();
            this.bt_pos_left = new System.Windows.Forms.Button();
            this.bt_pos_up = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.bt_scene_small = new System.Windows.Forms.Button();
            this.bt_scene_big = new System.Windows.Forms.Button();
            this.bt_scene_reset = new System.Windows.Forms.Button();
            this.timerClick = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabpanel.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bt_hideshow);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1335, 818);
            this.panel2.TabIndex = 5;
            // 
            // bt_hideshow
            // 
            this.bt_hideshow.Location = new System.Drawing.Point(216, 284);
            this.bt_hideshow.Name = "bt_hideshow";
            this.bt_hideshow.Size = new System.Drawing.Size(19, 40);
            this.bt_hideshow.TabIndex = 6;
            this.bt_hideshow.Text = "<";
            this.bt_hideshow.UseVisualStyleBackColor = true;
            this.bt_hideshow.Click += new System.EventHandler(this.bt_hideshow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 818);
            this.panel1.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_video_1);
            this.groupBox4.Location = new System.Drawing.Point(3, 641);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "视频监控";
            // 
            // bt_video_1
            // 
            this.bt_video_1.Location = new System.Drawing.Point(7, 21);
            this.bt_video_1.Name = "bt_video_1";
            this.bt_video_1.Size = new System.Drawing.Size(75, 23);
            this.bt_video_1.TabIndex = 0;
            this.bt_video_1.Text = "摄像头1";
            this.bt_video_1.UseVisualStyleBackColor = true;
            this.bt_video_1.Click += new System.EventHandler(this.bt_video_1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_search);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_search);
            this.groupBox3.Location = new System.Drawing.Point(2, 517);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "检索";
            // 
            // bt_search
            // 
            this.bt_search.Location = new System.Drawing.Point(43, 71);
            this.bt_search.Name = "bt_search";
            this.bt_search.Size = new System.Drawing.Size(75, 23);
            this.bt_search.TabIndex = 2;
            this.bt_search.Text = "查找";
            this.bt_search.UseVisualStyleBackColor = true;
            this.bt_search.Click += new System.EventHandler(this.bt_search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "托盘号：";
            // 
            // tb_search
            // 
            this.tb_search.Location = new System.Drawing.Point(66, 30);
            this.tb_search.Name = "tb_search";
            this.tb_search.Size = new System.Drawing.Size(100, 21);
            this.tb_search.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_goon);
            this.groupBox2.Controls.Add(this.bt_stop);
            this.groupBox2.Controls.Add(this.bt_pause);
            this.groupBox2.Controls.Add(this.bt_play);
            this.groupBox2.Location = new System.Drawing.Point(3, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "控制";
            // 
            // bt_goon
            // 
            this.bt_goon.Location = new System.Drawing.Point(100, 62);
            this.bt_goon.Name = "bt_goon";
            this.bt_goon.Size = new System.Drawing.Size(75, 23);
            this.bt_goon.TabIndex = 10;
            this.bt_goon.Text = "继续";
            this.bt_goon.UseVisualStyleBackColor = true;
            this.bt_goon.Click += new System.EventHandler(this.bt_goon_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(100, 20);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 23);
            this.bt_stop.TabIndex = 9;
            this.bt_stop.Text = "停止";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // bt_pause
            // 
            this.bt_pause.Location = new System.Drawing.Point(12, 62);
            this.bt_pause.Name = "bt_pause";
            this.bt_pause.Size = new System.Drawing.Size(75, 23);
            this.bt_pause.TabIndex = 8;
            this.bt_pause.Text = "暂停";
            this.bt_pause.UseVisualStyleBackColor = true;
            this.bt_pause.Click += new System.EventHandler(this.bt_pause_Click);
            // 
            // bt_play
            // 
            this.bt_play.Location = new System.Drawing.Point(12, 20);
            this.bt_play.Name = "bt_play";
            this.bt_play.Size = new System.Drawing.Size(75, 23);
            this.bt_play.TabIndex = 7;
            this.bt_play.Text = "启动";
            this.bt_play.UseVisualStyleBackColor = true;
            this.bt_play.Click += new System.EventHandler(this.bt_play_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabpanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 318);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // tabpanel
            // 
            this.tabpanel.Controls.Add(this.tabPage4);
            this.tabpanel.Controls.Add(this.tabPage1);
            this.tabpanel.Controls.Add(this.tabPage2);
            this.tabpanel.Controls.Add(this.tabPage3);
            this.tabpanel.Location = new System.Drawing.Point(3, 20);
            this.tabpanel.Name = "tabpanel";
            this.tabpanel.SelectedIndex = 0;
            this.tabpanel.Size = new System.Drawing.Size(201, 292);
            this.tabpanel.TabIndex = 7;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.treeView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(193, 266);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "定位";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            treeNode43.Name = "节点2";
            treeNode43.Text = "悬挂线";
            treeNode44.Name = "节点10";
            treeNode44.Text = "配餐车";
            treeNode45.Name = "节点3";
            treeNode45.Text = "配餐区";
            treeNode46.Name = "节点11";
            treeNode46.Text = "1号车";
            treeNode47.Name = "节点12";
            treeNode47.Text = "2号车";
            treeNode48.Name = "节点13";
            treeNode48.Text = "3号车";
            treeNode49.Name = "节点14";
            treeNode49.Text = "4号车";
            treeNode50.Name = "节点15";
            treeNode50.Text = "5号车";
            treeNode51.Name = "节点4";
            treeNode51.Text = "AGV小车";
            treeNode52.Name = "节点16";
            treeNode52.Text = "1号堆垛机";
            treeNode53.Name = "节点17";
            treeNode53.Text = "2号堆垛机";
            treeNode54.Name = "节点19";
            treeNode54.Text = "3号堆垛机";
            treeNode55.Name = "节点20";
            treeNode55.Text = "入库穿梭车";
            treeNode56.Name = "节点21";
            treeNode56.Text = "出库穿梭车";
            treeNode57.Name = "节点5";
            treeNode57.Text = "采购库";
            treeNode58.Name = "";
            treeNode58.Text = "物流设备";
            treeNode59.Name = "节点6";
            treeNode59.Text = "马扎克";
            treeNode60.Name = "节点7";
            treeNode60.Text = "柔性制造";
            treeNode61.Name = "节点8";
            treeNode61.Text = "MF制造";
            treeNode62.Name = "节点9";
            treeNode62.Text = "轴杆加工";
            treeNode63.Name = "节点1";
            treeNode63.Text = "机床设备";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode58,
            treeNode63});
            this.treeView1.Size = new System.Drawing.Size(187, 257);
            this.treeView1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bt_view_reset);
            this.tabPage1.Controls.Add(this.bt_view_before);
            this.tabPage1.Controls.Add(this.bt_view_left);
            this.tabPage1.Controls.Add(this.bt_view_down);
            this.tabPage1.Controls.Add(this.bt_view_after);
            this.tabPage1.Controls.Add(this.bt_view_right);
            this.tabPage1.Controls.Add(this.bt_view_up);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(193, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "视角";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bt_view_reset
            // 
            this.bt_view_reset.Location = new System.Drawing.Point(15, 170);
            this.bt_view_reset.Name = "bt_view_reset";
            this.bt_view_reset.Size = new System.Drawing.Size(75, 23);
            this.bt_view_reset.TabIndex = 6;
            this.bt_view_reset.Text = "还原";
            this.bt_view_reset.UseVisualStyleBackColor = true;
            this.bt_view_reset.Click += new System.EventHandler(this.bt_view_reset_Click);
            // 
            // bt_view_before
            // 
            this.bt_view_before.Location = new System.Drawing.Point(15, 70);
            this.bt_view_before.Name = "bt_view_before";
            this.bt_view_before.Size = new System.Drawing.Size(75, 23);
            this.bt_view_before.TabIndex = 5;
            this.bt_view_before.Text = "前视";
            this.bt_view_before.UseVisualStyleBackColor = true;
            this.bt_view_before.Click += new System.EventHandler(this.bt_view_before_Click);
            // 
            // bt_view_left
            // 
            this.bt_view_left.Location = new System.Drawing.Point(15, 120);
            this.bt_view_left.Name = "bt_view_left";
            this.bt_view_left.Size = new System.Drawing.Size(75, 23);
            this.bt_view_left.TabIndex = 4;
            this.bt_view_left.Text = "左视";
            this.bt_view_left.UseVisualStyleBackColor = true;
            this.bt_view_left.Click += new System.EventHandler(this.bt_view_left_Click);
            // 
            // bt_view_down
            // 
            this.bt_view_down.Location = new System.Drawing.Point(96, 20);
            this.bt_view_down.Name = "bt_view_down";
            this.bt_view_down.Size = new System.Drawing.Size(75, 23);
            this.bt_view_down.TabIndex = 3;
            this.bt_view_down.Text = "俯视";
            this.bt_view_down.UseVisualStyleBackColor = true;
            this.bt_view_down.Click += new System.EventHandler(this.bt_view_down_Click);
            // 
            // bt_view_after
            // 
            this.bt_view_after.Location = new System.Drawing.Point(96, 70);
            this.bt_view_after.Name = "bt_view_after";
            this.bt_view_after.Size = new System.Drawing.Size(75, 23);
            this.bt_view_after.TabIndex = 2;
            this.bt_view_after.Text = "后视";
            this.bt_view_after.UseVisualStyleBackColor = true;
            this.bt_view_after.Click += new System.EventHandler(this.bt_view_after_Click);
            // 
            // bt_view_right
            // 
            this.bt_view_right.Location = new System.Drawing.Point(96, 120);
            this.bt_view_right.Name = "bt_view_right";
            this.bt_view_right.Size = new System.Drawing.Size(75, 23);
            this.bt_view_right.TabIndex = 1;
            this.bt_view_right.Text = "右视";
            this.bt_view_right.UseVisualStyleBackColor = true;
            this.bt_view_right.Click += new System.EventHandler(this.bt_view_right_Click);
            // 
            // bt_view_up
            // 
            this.bt_view_up.Location = new System.Drawing.Point(15, 20);
            this.bt_view_up.Name = "bt_view_up";
            this.bt_view_up.Size = new System.Drawing.Size(75, 23);
            this.bt_view_up.TabIndex = 0;
            this.bt_view_up.Text = "仰视";
            this.bt_view_up.UseVisualStyleBackColor = true;
            this.bt_view_up.Click += new System.EventHandler(this.bt_view_up_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.bt_pos_right);
            this.tabPage2.Controls.Add(this.bt_pos_down);
            this.tabPage2.Controls.Add(this.bt_pos_left);
            this.tabPage2.Controls.Add(this.bt_pos_up);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(193, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "坐标";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // bt_pos_right
            // 
            this.bt_pos_right.Location = new System.Drawing.Point(96, 70);
            this.bt_pos_right.Name = "bt_pos_right";
            this.bt_pos_right.Size = new System.Drawing.Size(75, 23);
            this.bt_pos_right.TabIndex = 5;
            this.bt_pos_right.Text = "右移";
            this.bt_pos_right.UseVisualStyleBackColor = true;
            this.bt_pos_right.Click += new System.EventHandler(this.bt_pos_right_Click);
            // 
            // bt_pos_down
            // 
            this.bt_pos_down.Location = new System.Drawing.Point(96, 20);
            this.bt_pos_down.Name = "bt_pos_down";
            this.bt_pos_down.Size = new System.Drawing.Size(75, 23);
            this.bt_pos_down.TabIndex = 4;
            this.bt_pos_down.Text = "下移";
            this.bt_pos_down.UseVisualStyleBackColor = true;
            this.bt_pos_down.Click += new System.EventHandler(this.bt_pos_down_Click);
            // 
            // bt_pos_left
            // 
            this.bt_pos_left.Location = new System.Drawing.Point(15, 70);
            this.bt_pos_left.Name = "bt_pos_left";
            this.bt_pos_left.Size = new System.Drawing.Size(75, 23);
            this.bt_pos_left.TabIndex = 3;
            this.bt_pos_left.Text = "左移";
            this.bt_pos_left.UseVisualStyleBackColor = true;
            this.bt_pos_left.Click += new System.EventHandler(this.bt_pos_left_Click);
            // 
            // bt_pos_up
            // 
            this.bt_pos_up.Location = new System.Drawing.Point(15, 20);
            this.bt_pos_up.Name = "bt_pos_up";
            this.bt_pos_up.Size = new System.Drawing.Size(75, 23);
            this.bt_pos_up.TabIndex = 2;
            this.bt_pos_up.Text = "上移";
            this.bt_pos_up.UseVisualStyleBackColor = true;
            this.bt_pos_up.Click += new System.EventHandler(this.bt_pos_up_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.bt_scene_small);
            this.tabPage3.Controls.Add(this.bt_scene_big);
            this.tabPage3.Controls.Add(this.bt_scene_reset);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(193, 266);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "场景";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // bt_scene_small
            // 
            this.bt_scene_small.Location = new System.Drawing.Point(15, 20);
            this.bt_scene_small.Name = "bt_scene_small";
            this.bt_scene_small.Size = new System.Drawing.Size(75, 23);
            this.bt_scene_small.TabIndex = 4;
            this.bt_scene_small.Text = "缩小";
            this.bt_scene_small.UseVisualStyleBackColor = true;
            this.bt_scene_small.Click += new System.EventHandler(this.bt_scene_small_Click);
            // 
            // bt_scene_big
            // 
            this.bt_scene_big.Location = new System.Drawing.Point(96, 20);
            this.bt_scene_big.Name = "bt_scene_big";
            this.bt_scene_big.Size = new System.Drawing.Size(75, 23);
            this.bt_scene_big.TabIndex = 3;
            this.bt_scene_big.Text = "放大";
            this.bt_scene_big.UseVisualStyleBackColor = true;
            this.bt_scene_big.Click += new System.EventHandler(this.bt_scene_big_Click);
            // 
            // bt_scene_reset
            // 
            this.bt_scene_reset.Location = new System.Drawing.Point(15, 70);
            this.bt_scene_reset.Name = "bt_scene_reset";
            this.bt_scene_reset.Size = new System.Drawing.Size(75, 23);
            this.bt_scene_reset.TabIndex = 2;
            this.bt_scene_reset.Text = "还原";
            this.bt_scene_reset.UseVisualStyleBackColor = true;
            this.bt_scene_reset.Click += new System.EventHandler(this.bt_scene_reset_Click);
            // 
            // timerClick
            // 
            this.timerClick.Tick += new System.EventHandler(this.timerClick_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 818);
            this.Controls.Add(this.panel2);
            this.Name = "MainForm";
            this.Text = "吴忠仪表三维监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabpanel.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bt_hideshow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bt_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_search;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bt_goon;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.Button bt_pause;
        private System.Windows.Forms.Button bt_play;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabpanel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button bt_view_reset;
        private System.Windows.Forms.Button bt_view_before;
        private System.Windows.Forms.Button bt_view_left;
        private System.Windows.Forms.Button bt_view_down;
        private System.Windows.Forms.Button bt_view_after;
        private System.Windows.Forms.Button bt_view_right;
        private System.Windows.Forms.Button bt_view_up;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button bt_pos_right;
        private System.Windows.Forms.Button bt_pos_down;
        private System.Windows.Forms.Button bt_pos_left;
        private System.Windows.Forms.Button bt_pos_up;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button bt_scene_small;
        private System.Windows.Forms.Button bt_scene_big;
        private System.Windows.Forms.Button bt_scene_reset;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button bt_video_1;
        private System.Windows.Forms.Timer timerClick;

    }
}
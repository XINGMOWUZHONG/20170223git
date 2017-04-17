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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("悬挂线");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("配餐车");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("配餐区", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("1号车");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("2号车");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("3号车");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("4号车");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("5号车");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("AGV小车", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("1号堆垛机");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("2号堆垛机");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("3号堆垛机");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("入库穿梭车");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("出库穿梭车");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("采购库", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("采购库2");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("窄巷道库");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("物流设备", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode9,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("任务信息");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("马扎克", new System.Windows.Forms.TreeNode[] {
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("任务信息");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("柔性制造", new System.Windows.Forms.TreeNode[] {
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("任务信息");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("MF制造", new System.Windows.Forms.TreeNode[] {
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("任务信息");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("轴杆加工", new System.Windows.Forms.TreeNode[] {
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("机床设备", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode22,
            treeNode24,
            treeNode26});
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
            this.bt_hideshow.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bt_hideshow.Location = new System.Drawing.Point(216, 309);
            this.bt_hideshow.Name = "bt_hideshow";
            this.bt_hideshow.Size = new System.Drawing.Size(19, 40);
            this.bt_hideshow.TabIndex = 6;
            this.bt_hideshow.Text = "<";
            this.bt_hideshow.UseVisualStyleBackColor = false;
            this.bt_hideshow.Click += new System.EventHandler(this.bt_hideshow_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 725);
            this.panel1.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.bt_video_1);
            this.groupBox4.Location = new System.Drawing.Point(3, 600);
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
            this.groupBox3.Location = new System.Drawing.Point(3, 475);
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
            this.groupBox2.Location = new System.Drawing.Point(3, 25);
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
            this.groupBox1.Location = new System.Drawing.Point(3, 150);
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
            this.treeView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "v_ocs";
            treeNode1.Text = "悬挂线";
            treeNode2.Name = "pcc_car";
            treeNode2.Text = "配餐车";
            treeNode3.Name = "v_pcc";
            treeNode3.Text = "配餐区";
            treeNode4.Name = "agv_car1";
            treeNode4.Text = "1号车";
            treeNode5.Name = "agv_car2";
            treeNode5.Text = "2号车";
            treeNode6.Name = "agv_car3";
            treeNode6.Text = "3号车";
            treeNode7.Name = "agv_car4";
            treeNode7.Text = "4号车";
            treeNode8.Name = "agv_car5";
            treeNode8.Text = "5号车";
            treeNode9.Name = "v_agv";
            treeNode9.Text = "AGV小车";
            treeNode10.Name = "cgk_car1";
            treeNode10.Text = "1号堆垛机";
            treeNode11.Name = "cgk_car2";
            treeNode11.Text = "2号堆垛机";
            treeNode12.Name = "cgk_car3";
            treeNode12.Text = "3号堆垛机";
            treeNode13.Name = "cgk_csc_in";
            treeNode13.Text = "入库穿梭车";
            treeNode14.Name = "cgk_csc_out";
            treeNode14.Text = "出库穿梭车";
            treeNode15.Name = "v_cgk";
            treeNode15.Text = "采购库";
            treeNode16.Name = "v_cgk2";
            treeNode16.Text = "采购库2";
            treeNode17.Name = "v_cgk3";
            treeNode17.Text = "窄巷道库";
            treeNode18.Name = "logistics";
            treeNode18.Text = "物流设备";
            treeNode19.Name = "workinfo1";
            treeNode19.Text = "任务信息";
            treeNode20.Name = "v_machine_1";
            treeNode20.Text = "马扎克";
            treeNode21.Name = "workinfo2";
            treeNode21.Text = "任务信息";
            treeNode22.Name = "v_machine_2";
            treeNode22.Text = "柔性制造";
            treeNode23.Name = "workinfo3";
            treeNode23.Text = "任务信息";
            treeNode24.Name = "v_machine_3";
            treeNode24.Text = "MF制造";
            treeNode25.Name = "workinfo4";
            treeNode25.Text = "任务信息";
            treeNode26.Name = "v_machine_4";
            treeNode26.Text = "轴杆加工";
            treeNode27.Name = "machine";
            treeNode27.Text = "机床设备";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode27});
            this.treeView1.Size = new System.Drawing.Size(193, 266);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
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
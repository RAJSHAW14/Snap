using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace Snap
{
    public partial class parent : Form
    {
        private int childFormNumber = 0;
        SpeechSynthesizer speechSynthesizerObj;
        public parent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void addItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vENODRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sttleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void batchcodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void batchlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void batcconsumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void rEQUESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emb_inhouse_List inhouse = new emb_inhouse_List();
            inhouse.MdiParent = this;
            inhouse.Show();
        }

        private void iSSUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emb_outhouse_list outhouse = new emb_outhouse_list();
            outhouse.MdiParent = this;
            outhouse.Show();
        }

        private void lISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void gRNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inhouse_order_entry order = new inhouse_order_entry();
            order.MdiParent = this;
            order.Show();

        }

        private void eNTRYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            in_houser_emb_dpr dpr = new in_houser_emb_dpr();
            dpr.MdiParent = this;
            dpr.Show();
        }

        private void outHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emb_outhouse_list list = new emb_outhouse_list();
            list.MdiParent = this;
            list.Show();
        }

        private void nEWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            outhouse_order_cart cart = new outhouse_order_cart();
            cart.MdiParent = this;
            cart.Show();
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update_dpr_entry update = new update_dpr_entry();
            update.MdiParent = this;
            update.Show();
        }

        private void tIMESLOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* emb_time_slot time = new emb_time_slot();
            time.MdiParent = this;
            time.Show();*/
        }

        private void rEPLACEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            replace_order_number replace = new replace_order_number();
            replace.MdiParent = this;
            replace.Show();
        }

        private void inHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emb_inhouse_List inhouse = new emb_inhouse_List();
            inhouse.MdiParent = this;
            inhouse.Show();
        }

        private void parent_Load(object sender, EventArgs e)
        { 
             speechSynthesizerObj = new SpeechSynthesizer();
             speechSynthesizerObj.SelectVoiceByHints(VoiceGender.Female);     
             speechSynthesizerObj.SpeakAsync(Welcome.Text);
                       
        }

        private void embroideryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void parent_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void iNHOUSEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            inhouse_emb_receive receive = new inhouse_emb_receive();
            receive.MdiParent = this;
            receive.Show();
        }

        private void oUTHOUSEToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            outhouse_emb_receive receive = new outhouse_emb_receive();
            receive.MdiParent = this;
            receive.Show();
        }
        
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT.user_list list = new IT.user_list();
            list.MdiParent = this;
            list.Show();
        }

        private void addNewCatagoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT.category category = new IT.category();
            category.MdiParent = this;
            category.Show();
        }


        private void vIEWSTATUSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            product_status_view view = new product_status_view();
            view.MdiParent = this;
            view.WindowState = FormWindowState.Maximized;
            view.Show();
        }

        private void sTYLEMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            style_master_date date = new style_master_date();
            date.MdiParent = this;
            date.Show();
        }

        private void aDDITEMToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            item_list_new list = new item_list_new();
            list.MdiParent = this;
            list.Show();
        }

        private void aDDVENDORToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vendor_list list = new vendor_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pURCHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabirc_receive RECEIVE = new non_fabirc_receive();
            RECEIVE.MdiParent = this;
            RECEIVE.Show();
        }

        private void sENDREQUESTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sENDREQUESTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            non_fabric_request request = new non_fabric_request();
            request.MdiParent = this;
            request.Show();
        }

        private void vIEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Request_list list = new Request_list();
            list.MdiParent = this;
            list.Show();
        }

        private void sENDREQUESTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            non_fabric_request request = new non_fabric_request();
            request.MdiParent = this;
            request.Show();
        }

        private void vIEWREQUESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Request_list list = new Request_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pENDINGTOISSUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabric_pending_to_issue issue = new non_fabric_pending_to_issue();
            issue.MdiParent = this;
            issue.Show();
        }

        private void iSSUEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            non_fabric_issue issue = new non_fabric_issue();
            issue.MdiParent = this;
            issue.Show();
        }

        private void vIEWISSUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabirc_issue_view view = new non_fabirc_issue_view();
            view.MdiParent = this;
            view.Show();
        }

        private void pURCASERETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabric_purchase_return_list list = new non_fabric_purchase_return_list();
            list.MdiParent = this;
            list.Show();
        }

        private void dEPARTMENTRETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lISTToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            non_fabric_d_return_list list = new non_fabric_d_return_list();
            list.MdiParent=this;
            list.Show();
        }

        private void cARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabric_department_return rt = new non_fabric_department_return();
            rt.MdiParent = this;
            rt.Show();
        }

        private void oRDERTIMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dpr_order_time_view dpr = new dpr_order_time_view();
            dpr.MdiParent = this;
            dpr.Show();
        }

        private void nEGATIVEITEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabirc_negative_stock stock = new non_fabirc_negative_stock();
            stock.MdiParent = this;
            stock.Show();
        }

        private void pRODUCTENTRYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kurta_product_entry kurta = new kurta_product_entry();
            kurta.MdiParent = this;
            kurta.Show();
        }

        private void aLLPRODUCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kurta_all_product product = new kurta_all_product();
            product.MdiParent = this;
            product.Show();
        }

        private void iTEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.access_item item = new accessiories_forms.access_item();
            item.MdiParent=this;
            item.Show();
        }

        private void gRNToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            accessiories_forms.grn_list list = new accessiories_forms.grn_list();
            list.MdiParent = this;
            list.Show();
        }

        private void sENDREQUESTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            accessiories_forms.item_request request = new accessiories_forms.item_request();
            request.MdiParent = this;
            request.Show();
        }

        private void vIEWREQUESTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.request_list list = new accessiories_forms.request_list();
            list.MdiParent = this;
            list.Show();
        }

        private void nEGATIVEITEMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.negative_stock negative = new accessiories_forms.negative_stock();
            negative.MdiParent = this;
            negative.Show();
        }

        private void iSSUEENTRYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.item_issue issue = new accessiories_forms.item_issue();
            issue.MdiParent = this;
            issue.Show();
        }

        private void vIEWISSUEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.view_issue view1 = new accessiories_forms.view_issue();
            view1.MdiParent = this;
            view1.Show();
        }

        private void pENDINGTOISSUEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.pending_to_issue pending = new accessiories_forms.pending_to_issue();
            pending.MdiParent = this;
            pending.Show();
        }

        private void pURCHASERETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.p_return_list list = new accessiories_forms.p_return_list();
            list.MdiParent = this;
            list.Show();
        }

        private void aDDSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabric_add_stock add_stock = new non_fabric_add_stock();
            add_stock.MdiParent = this;
            add_stock.Show();
        }

        private void eMBMASTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costing.emb_master_list list = new costing.emb_master_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pENDINGCONSUMPTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costing.emb_consumption_pending pending = new costing.emb_consumption_pending();
            pending.MdiParent = this;
            pending.Show();
        }

        private void cONSUMPTIONLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costing.emb_consumption_list list = new costing.emb_consumption_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pARAMETERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.qc_parameter_list list = new accessiories_forms.qc_parameter_list();
            list.MdiParent = this;
            list.Show();
        }

        private void nEWQCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.d_qc_list list = new accessiories_forms.d_qc_list();
            list.MdiParent = this;
            list.Show();
        }

        private void aPPROVEDLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.approved_qc_item_list list = new accessiories_forms.approved_qc_item_list();
            list.MdiParent = this;
            list.Show();
        }

        private void rEJECTLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.rejected_qc_item_list list = new accessiories_forms.rejected_qc_item_list();
            list.MdiParent = this;
            list.Show();
        }

        private void nEWQCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.final_qc_list list = new accessiories_forms.final_qc_list();
            list.MdiParent = this;
            list.Show();
        }

        private void aPPROVEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.approved_qc_item_list list = new accessiories_forms.approved_qc_item_list();
            list.MdiParent = this;
            list.Show();
        }

        private void rEJECTEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.rejected_qc_item_list list = new accessiories_forms.rejected_qc_item_list();
            list.MdiParent = this;
            list.Show();
        }

        private void aDDNEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costing.style_costing_list garment = new costing.style_costing_list();
            garment.MdiParent = this;
            garment.Show();
        }

        private void sTYLEMASTERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            costing.style_master_list list = new costing.style_master_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pENDINGLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            costing.style_pending_consumption_list pending = new costing.style_pending_consumption_list();
            pending.MdiParent = this;
            pending.Show();
        }

        private void uPLOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void uPLOADToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.product_upload upload = new accessiories_forms.product_upload();
            upload.MdiParent = this;
            upload.Show();
        }

        private void lISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.all_product product = new accessiories_forms.all_product();
            product.MdiParent = this;
            product.Show();
        }

        private void pENDINGLISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.final_qc_list list = new accessiories_forms.final_qc_list();
            list.button2.Visible = false;
            list.MdiParent = this;
            list.Text = "PENDING QC LIST";
            list.Show();
        }

        private void grnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void cOSTINGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void styleMaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.style_master_list list = new accessiories_forms.style_master_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pENDINGLISTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            accessiories_forms.style_pending_cons_list pending = new accessiories_forms.style_pending_cons_list();
            pending.MdiParent = this;
            pending.Show();
        }

        private void cOSTINGLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accessiories_forms.style_costing_list costing = new accessiories_forms.style_costing_list();
            costing.MdiParent = this;
            costing.Show();
        }

        private void aDDSTOCKToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            accessiories_forms.acc_add_stock add_stock = new accessiories_forms.acc_add_stock();
            add_stock.MdiParent = this;
            add_stock.Show();
        }

        private void dESIGNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMC.design_master_list list = new CMC.design_master_list();
            list.MdiParent = this;
            list.Show();
        }

        private void oRDERToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CMC.order_list list = new CMC.order_list();
            list.MdiParent = this;
            list.Show();
        }

        private void sTOCKLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMC.mat_stock_list list = new CMC.mat_stock_list();
            list.MdiParent = this;
            list.Show();
        }

        private void lISTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CMC.cmc_mat_stock_in stock_in = new CMC.cmc_mat_stock_in();
            stock_in.MdiParent = this;
            stock_in.Show();
        }

        private void cARTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CMC.add_mat_stock stock = new CMC.add_mat_stock();
            stock.MdiParent = this;
            stock.Show();
        }

        private void lISTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CMC.mat_out_list MAT_OUT = new CMC.mat_out_list();
            MAT_OUT.MdiParent = this;
            MAT_OUT.Show();
        }

        private void cARTToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            CMC.cmc_mat_stock_out out1 = new CMC.cmc_mat_stock_out();
            out1.MdiParent = this;
            out1.Show();
        }

        private void cmcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void vENDORToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fabric.vendor_list list = new fabric.vendor_list();
            list.MdiParent = this;
            list.Show();
        }

        private void iTEMToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fabric.item_list list = new fabric.item_list();
            list.MdiParent = this;
            list.Show();
        }

        private void pURCHASEORDERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.purchase_order_list list = new fabric.purchase_order_list();
            list.MdiParent = this;
            list.Show();
        }

        private void gRNToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            fabric.grn_list grn = new fabric.grn_list();
            grn.MdiParent = this;
            grn.Show();
        }

        private void tHANLISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.pending_than_list list = new fabric.pending_than_list();
            list.MdiParent = this;
            list.Show();
        }

        private void tHANLISTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fabric.receive_than_list list = new fabric.receive_than_list();
            list.MdiParent = this;
            list.Show();
        }

        private void sENTREQUESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.request_cart cart = new fabric.request_cart();
            cart.MdiParent = this;
            cart.Show();
        }

        private void pENDINGTOISSUEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fabric.pending_to_issue issue = new fabric.pending_to_issue();
            issue.MdiParent = this;
            issue.Show();
        }

        private void iSSUEToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            fabric.issue iss = new fabric.issue();
            iss.MdiParent = this;
            iss.Show();
        }

        private void iTEMToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            S_FABRIC.item_list LIST = new S_FABRIC.item_list();
            LIST.MdiParent = this;
            LIST.Show();
        }

        private void pENDINGQCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.pending_to_qc qc = new fabric.pending_to_qc();
            qc.MdiParent = this;
            qc.Show();
        }

        private void aPPROVELISTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.approve_list list = new fabric.approve_list();
            list.MdiParent = this;
            list.Show();
        }

        private void vIEWISSUEToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            fabric.issue_list list = new fabric.issue_list();
            list.MdiParent = this;
            list.Show();
        }

        private void vIEWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fabric.fabric_stock_summery summery = new fabric.fabric_stock_summery();
            summery.MdiParent = this;
            summery.Show();
        }

        private void vIEWPRODUCTISSUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fabric.p_code_wise_issue_view view = new fabric.p_code_wise_issue_view();
            view.MdiParent = this;
            view.Show();
        }

        private void lISTToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            CMC.cmc_production_list list = new CMC.cmc_production_list();
            list.MdiParent = this;
            list.Show();
        }

        private void cARTToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            CMC.cmc_production_time time = new CMC.cmc_production_time();
            time.MdiParent = this;
            time.Show();
        }

        private void dEPTRETURNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabric_department_return rtr = new non_fabric_department_return();
            rtr.MdiParent = this;
            rtr.Show();
        }

        private void iSSUEREPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void aMOUNTWISEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabirc.issue_report_amount report = new non_fabirc.issue_report_amount();
            report.MdiParent = this;
            report.Show();
        }

        private void cATEGORYISEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            non_fabirc.issue_report_category report = new non_fabirc.issue_report_category();
            report.MdiParent = this;
            report.Show();
        }

        private void aMOUNTWISEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            non_fabirc.purchase_report_amount report = new non_fabirc.purchase_report_amount();
            report.MdiParent = this;
            report.Show();
        }

        private void aDDISSUESTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT.serial_list list = new IT.serial_list();
            list.MdiParent = this;
            list.Show();
        }

        private void vIEWSTOCKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IT.stock_list list = new IT.stock_list();
            list.MdiParent = this;
            list.Show();
        }
    }
}

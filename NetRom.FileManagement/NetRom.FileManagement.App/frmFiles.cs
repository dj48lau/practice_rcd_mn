using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Netrom.FileManagement.BusinessLogic.Services;
using NetRom.FileManagement.BusinessLogic;
using NetRom.FileManagement.Model;

namespace WindowsFormsApplication1
{
    public partial class frmFiles : Form
    {
        public frmFiles()
        {
            InitializeComponent();     
        }

        private void txtboxSearchName_KeyUp(object sender, KeyEventArgs e)
        {
            FileService fs = new FileService();
            gridfiles.DataSource = fs.GetFilesByName(txtSearch.Text); 
        }

        private void frmFiles_Load(object sender, EventArgs e)
        {
            FileService fs = new FileService();
            gridfiles.DataSource = fs.GetAllFiles();
            ((ListBox)cblistFileTypes).DataSource = fs.GetAllFileTypes();
            ((ListBox)cblistFileTypes).DisplayMember = "TypeName";
            ((ListBox)cblistFileTypes).ValueMember = "FileTypeId";

        }

        private void FillGrid()
        {
            FileService fs = new FileService();
            gridfiles.DataSource = fs.GetFiles(txtSearch.Text, cblistFileTypes.SelectedItems.Cast<FileType>(), dtpStartDate.Value, dtpEndDate.Value);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cblistFileTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}

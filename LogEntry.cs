using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TeamTrack
{
    public partial class LogEntry : Form
    {
        public LogEntry()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// Update the grid control and populate the Team Name Listbox.
        /// </summary>
        private void UpdateGrids()
        {
            m_logDataGridView.SuspendLayout();
            m_logTableAdapter.FillLog(this.m_logDataSet.LogData);
            int LastRow = Math.Max(m_logDataGridView.RowCount - 1, 0);
            int lastRowHt = (LastRow == 0) ? 
                m_logDataGridView.RowTemplate.Height : m_logDataGridView.Rows[LastRow].Height;
            int n_Rows = m_logDataGridView.Height / lastRowHt;
            int n_Start = m_logDataGridView.RowCount - n_Rows;
            n_Start = Math.Max(0, n_Start);
            if (m_logDataGridView.RowCount > 0)
            {
                m_logDataGridView.FirstDisplayedScrollingRowIndex = n_Start;
            }
            m_logDataGridView.ResumeLayout();
            
            
            m_NameAdd.SuspendLayout();
            m_NameAdd.Items.Clear();
            foreach (LogDataSet.LogDataRow lht in m_logTableAdapter.GetNames().Rows)
            {
                m_NameAdd.Items.Add(lht.Name);
            }
            m_NameAdd.ResumeLayout();
        }

        private void LogEntry_Load(object sender, EventArgs e)
        {
            try
            {
                UpdateGrids();
                if (m_historyTableAdapter.Connection.State == ConnectionState.Closed)
                {
                    m_historyTableAdapter.Connection.Open();
                }
            }
            catch (Exception ex)
            {
                m_LogEntryAdd.Text = ex.Message + ex.ToString();
                m_LogEntryAdd.Enabled = false;
                m_BtnAdd.Enabled = false;
            }
        }


        private void m_BtnAdd_Click(object sender, EventArgs e)
        {
            m_historyTableAdapter.Insert("", m_NameAdd.Text, "", "", "", "", "", DateTime.Now, "", null, m_LogEntryAdd.Text);
            UpdateGrids();
       }

        private void LogEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (m_historyTableAdapter.Connection.State == ConnectionState.Open)
                {
                    m_historyTableAdapter.Connection.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

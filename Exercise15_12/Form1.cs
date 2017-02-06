using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise15_12
{
    public partial class Form1 : Form
    {

        OleDbConnection con;
        OleDbCommand cmd;
        OleDbDataReader reader;
        Account[] accounts = new Account[5];

        public Form1()
        {
            InitializeComponent();

            String connect = "Provider=Microsoft.JET.OLEDB.4.0;" + @"data source=c:\Code\cst117_week5assignment\week5_exercises\Account.mdb";
            con = new OleDbConnection(connect);
            con.Open();
            cmd = con.CreateCommand();

            cmd.CommandText = "SELECT AccountNumber "
            + "FROM Accounts ORDER BY AccountNumber";
            reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                accounts[i] = new Account();
                accounts[i].setNum(reader.GetInt32(0));
                i++;
            }
            reader.Close();

            for(int j = 0; j < accounts.Length; j++)
            {
                listBox1.Items.Add(accounts[j].getNum());
                listBox2.Items.Add(accounts[j].getNum());
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            decimal transferAmount = 0;
            try
            {
                String transferBalance = textBox1.Text;
                transferAmount = (Convert.ToDecimal(transferBalance));
            }
            catch (FormatException f) { }

            decimal receivingCurrentBalance = 0;
            try
            {
                cmd.CommandText = "SELECT Balance "
            + "FROM Accounts WHERE AccountNumber = " + listBox1.SelectedItem.ToString();
                reader = cmd.ExecuteReader();
                receivingCurrentBalance = reader.GetDecimal(1); //error pulling in current balance, need to fix
                
            }catch(InvalidOperationException g) { }

            reader.Close();

            decimal sendingCurrentBalance = 0;
            try
            {
                cmd.CommandText = "SELECT Balance "
                + "FROM Accounts WHERE AccountNumber = " + listBox2.SelectedItem.ToString();
                reader = cmd.ExecuteReader();
                sendingCurrentBalance = reader.GetDecimal(1); //error pulling in current balance, need to fix
            }catch(InvalidOperationException h) { }
            


            reader.Close();

            decimal sendingNewBalance = sendingCurrentBalance - transferAmount;
            decimal ReceivingNewBalance = receivingCurrentBalance + transferAmount;

            //Updates do work and post correct value, need to correct pull of current account balance above to complete
            cmd.CommandText = "UPDATE Accounts SET Balance = " + ReceivingNewBalance + " WHERE AccountNumber = " + listBox2.SelectedItem.ToString();
            cmd.ExecuteNonQuery();

            cmd.CommandText = "UPDATE Accounts SET Balance = " + sendingNewBalance + " WHERE AccountNumber = " + listBox1.SelectedItem.ToString();
            cmd.ExecuteNonQuery();
        }
    }

    class Account
    {
        private int accountNumber;
        private double accountBalance;

        public Account() { }

        public Account(int num, double bal)
        {
            this.accountNumber = num;
            this.accountBalance = bal;
        }

        public void setNum(int num)
        {
            this.accountNumber = num;
        }

        public int getNum()
        {
            return accountNumber;
        }

        public void setBal(double bal)
        {
            this.accountBalance = bal;
        }

        public double getBal()
        {
            return accountBalance;
        }

        public String getStringBal()
        {
            return accountBalance.ToString();
        }

        public override String ToString()
        {
            return accountNumber.ToString();
        }

    }
}

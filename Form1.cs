﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduler_CPU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* ------------------------ FCFS ----------------------------------- */

        int n;//number of processes
        private void button1_Click(object sender, EventArgs e)
        {
            n = int.Parse(nOfProcesses.Text);
        }
        int []burst_time=new int[10];//max number of processe is 10
        int i = 0;
        int wtime=0,averageWtime=0;
        private void button2_Click(object sender, EventArgs e)
        {
            burst_time[i] = int.Parse(burstTime_text.Text);
            //burst_time.OrderBy()
            i++;
            if (n == i)
            {
                button2.Enabled = false;
                calculateWaitingTime();
            }
        }
        private void calculateWaitingTime()
        {
            for(int i=0;i<n;i++)
            {
                //gantt chart code
                averageWtime += wtime;
                wtime += burst_time[i];
            }
            waitingTime_text.Text = (averageWtime / n).ToString();
        }

        /* -------------------------- END FCFS ------------------------------ */


        /*---------------------- SJF mode Code --------------------------- */
        
        // number of process 
        int num_process;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            num_process = (int) numericUpDown1.Value;
        }

        // Preemptive check box
        private void checkBox1_Checked(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                label7.Visible = true;
                numericUpDown3.Visible = true;
            }
            else
            {
                label7.Visible = false;
                numericUpDown3.Visible = false;
            }
        }

        // store values accending
        double sjwtime, sjaverageWtime;
        List <int> vals = new List<int>();
        private void button3_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (vals.Count != num_process)
                {
                    vals.Add((int)numericUpDown2.Value);
                    vals.Sort();
                }
                else if (vals.Count == num_process)
                {
                    button3.Enabled = false;

                    //cal avg waiting time code
                    for (int j = 0; j < num_process; j++)
                    {
                        //gantt chart code
                        sjaverageWtime += sjwtime;
                        sjwtime += vals[j];
                    }

                    label9.Text = (sjaverageWtime / (double)num_process).ToString() + " msec";
                }
            }

            
            else
            {
                //preemtive code
                MessageBox.Show("shit still not done");
            }

            MessageBox.Show("Inserted");

        }

       /*---------------------------- End SJF mode Code-----------------------------*/


        /*----------------------------- priority mode code---------------------------*/

        //num of process
        int num_process_prio;
        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            num_process_prio = (int)numericUpDown5.Value;
        }

        // Preemptive checkbox
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label14.Visible = true;
                numericUpDown6.Visible = true;
            }
            else
            {
                label14.Visible = false;
                numericUpDown6.Visible = false;
            }
        }

        // store values and priority
        double prwtime, praverageWtime;
        List<int [] > pri_vals = new List <int[]>();
        private void button4_Click(object sender, EventArgs e)
        {
            if (!checkBox2.Checked)
            {
                int[] process = new int[2];
                process[0] = (int)numericUpDown4.Value; //time
                process[1] = (int)numericUpDown7.Value; //priority
                pri_vals.Add(process);
                pri_vals = pri_vals.OrderBy(arr => arr[1]).ToList(); //sorting based on priority

                if (pri_vals.Count == num_process_prio)
                {
                    button4.Enabled = false;

                    //cal avg waiting time code
                    for (int j = 0; j < num_process_prio; j++)
                    {
                        //gantt chart code
                        praverageWtime += prwtime;
                        prwtime += pri_vals[j][0];
                    }

                    label12.Text = (praverageWtime / (double)num_process_prio).ToString() + " msec";
                }
            }

            else
            {
                //preemtive code
                MessageBox.Show("shit still not done");
            }

            MessageBox.Show("Inserted");
        }

        /*-------------------- End priority mode code -------------------------- */
       

    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    [Serializable]
    public struct command_structure
    {
        public string command;
        public string description;
        public int max_argument;
    }

    public Canvas this_canvas;
    public float time_to_complete_minute = 15;
    public Text terminal_panel;
    public Text terminal_timer;
    public InputField input_command;
    public command_structure[] command_list;
    public string console_computer_title = "arch@root:~$";
    public Finish end_level;
    private Dictionary<string, string> untrusted_connect = new Dictionary<string, string>();
    public string[] normal_process;
    public string[] alert_process;
    private List<string> outnput_console_list = new List<string>();
    private List<string> ip_block_list = new List<string>();
    private List<string> input_all_command_list = new List<string>();

    private void calculate_quality_of_execution()
    {
        if (ip_block_list.Count == untrusted_connect.Count)
        {
            end_level.quality_of_execution += 50;
            return;
        }
        int error_count = ip_block_list.Count - untrusted_connect.Count;
        switch (error_count)
        {
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                end_level.quality_of_execution = end_level.quality_of_execution -  (int)Math.Round(error_count * 2f) + 30;
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                end_level.quality_of_execution = end_level.quality_of_execution - (int)Math.Round((error_count) * 2.5f) + 20;
                break;
            default:
                    end_level.quality_of_execution = end_level.quality_of_execution -  (int)Math.Round((error_count) * 3f) + 10;
                    break;
            }
        
    }
    private string get_random_ip()
    {
        return $"{Random.Range(1, 255)}.{Random.Range(0, 255)}.{Random.Range(0, 255)}.{Random.Range(0, 255)}";
    }
    void end_input_command(string command)
    {
        input_all_command_list.Add(command);
        string[] command_body = command.Split(' ');
        input_command.Select();
        input_command.text = "";
        if (command_body[0].Equals("help"))
        {
            if (command_body.Length > 1)
            {
                outnput_console_list.Add("This command don't have argument. Please write only help \n");
                return;
            }
            foreach (var value in command_list)
            {
                outnput_console_list.Add(
                    $"{console_computer_title} Command {value.command} | Performs {value.description} \n");
            }
            return;
        }
        
        if (command_body[0].Equals("ss"))
        {
            if (command_body.Length > 1)
            {
                outnput_console_list.Add($"{console_computer_title} {command_body[0]}: not have argument. Please you only [ss]\n");
                return;
            }
            
            outnput_console_list.Add($"{console_computer_title} {command_body[0]}\n");
            outnput_console_list.Add("\tState \t\t Local Address:Port \t\t\t\t Peer Address : Port \t\t Proccess\n");
            int untrusted_ip_page = Random.Range(0, 9);
            for (int i = 0; i <= 10; i++)
            {
                string local_port = Random.Range(1000, 9999).ToString();
                string out_port = Random.Range(1000, 9999).ToString();
                string local_ip = "192.168.0.2:" + local_port;
                string out_ip = string.Format("{0}:{1}",get_random_ip(), out_port);
                string program = normal_process[Random.Range(0, alert_process.Length - 1)];
                bool is_skip = false;
                if (untrusted_ip_page == i)
                {
                    foreach (var dictionary in untrusted_connect)
                    {
                        string ip = dictionary.Key;
                        bool is_usability = true;
                        foreach (var block in ip_block_list)
                        {
                            string[] block_ip = block.Split(':');
                            if (block_ip[0].Equals(ip))
                            {
                                is_usability = false;
                                break;
                            }
                        }
                        if (is_usability)
                        {
                            out_ip = $"{dictionary.Key}:{out_port}";
                            program = dictionary.Value;
                            break;
                        }
                    }
                }

                string[] out_ip_body = out_ip.Split(':');
                foreach (var ip_block in ip_block_list)
                {
                    if (out_ip_body[0].Equals(ip_block))
                    {
                        is_skip = true;
                        break;
                    }
                }
                
                if (is_skip)
                    continue;
                
                outnput_console_list.Add($"ESTAB \t\t {local_ip} \t\t\t\t {out_ip} \t\t {program}\n");

            }

            return;
        }

        if (command_body[0].Equals("iptable"))
        {
            outnput_console_list.Add($"{console_computer_title} {command}\n");
            if (command_body.Length != 3)
            {
                outnput_console_list.Add(
                    $"{console_computer_title} {command_body[0]}: have 2 argument | example: iptable <ip:port [172.118.121.244:9270]> <action [DROP | REJECT]>\n");
                return;

            }
            string[] replase_ip = command_body[1].Split('.');
            if (replase_ip.Length != 4)
            {
                outnput_console_list.Add(
                    $"{console_computer_title} {command_body[0]}: incorrect input ip address\n");
                return;
            }

            switch (command_body[2])
            {
                case "DROP":
                    outnput_console_list.Add(
                        $"{console_computer_title} You deleted the packet by ip: {command_body[1]}\n");
                    ip_block_list.Add(command_body[1]);
                    return;
                case "REJECT":
                    outnput_console_list.Add(
                        $"{console_computer_title} You rejected the packet by ip: {command_body[1]}\n");
                    return;
                default:
                    outnput_console_list.Add(
                        $"{console_computer_title} You are using an unknown action to ip: {command_body[1]}\n");
                    return;
            }
        }

        if (command_body[0].Equals("clear"))
        {
            outnput_console_list.Clear();
            terminal_panel.text = "";
            return;
        }
        
        bool is_valid = false;
        string input_value_convertation = "";
        foreach (var value in command_list)
        {
            if (value.command.Equals(command_body[0]))
            {
                is_valid = true;
                if (command_body.Length > value.max_argument)
                    input_value_convertation = $"This command have max argument {value.max_argument}\n";
                else if (command_body.Length == 1)
                    input_value_convertation = $"{command_body[0]}: {value.description} \n";
                else
                    input_value_convertation = $"{command} \n";
                break;
            }
                
        }

        if (!is_valid)
            input_value_convertation = command + ": command not found\n";

        outnput_console_list.Add($"{console_computer_title} {input_value_convertation}");
    }
    
    void Start()
    {
        this_canvas.gameObject.SetActive(true);
        this_canvas.enabled = true;
        end_level.this_canvas.gameObject.SetActive(false);
        end_level.this_canvas.enabled = false;
        time_to_complete_minute *= 60;
        terminal_panel.text = "";
        input_command.onEndEdit.AddListener(end_input_command);
        int untrusted_program_count = Random.Range(1, 5);
        for (int i = 0; i < untrusted_program_count; i++)
        {
            string untrusted_ip = $"{get_random_ip()}";
            string untrusted_po = alert_process[Random.Range(0, alert_process.Length - 1)];

            untrusted_connect.Add(untrusted_ip,untrusted_po);
        }
    }

    void Update()
    {
        if (time_to_complete_minute > 0)
        {
            time_to_complete_minute -= Time.deltaTime;
        }

        if (time_to_complete_minute <= 10)
        {
            end_level.quality_of_execution = 0;
            end_level.this_canvas.gameObject.SetActive(true);
            end_level.this_canvas.enabled = true;
            this_canvas.gameObject.SetActive(false);
            this_canvas.enabled = false;
        }

        terminal_timer.text = $"Time left [{(int)(time_to_complete_minute / 60)}] minutes";
        
        if (outnput_console_list.Count > 17)
        {
            int delete_item = outnput_console_list.Count - 17;
            for (int i = 0; i < delete_item; i++)
                outnput_console_list.Remove(outnput_console_list[0]);
        }

        if (ip_block_list.Count >= untrusted_connect.Count)
        {
            int real_block_untrusted_connect = 0;
            foreach (var block in ip_block_list)
            {
                string[] block_ip = block.Split(':');
                if (untrusted_connect.TryGetValue(block_ip[0], out _))
                    real_block_untrusted_connect++;
            }
            if (real_block_untrusted_connect == untrusted_connect.Count)
            {
                calculate_quality_of_execution();
                end_level.this_canvas.gameObject.SetActive(true);
                end_level.this_canvas.enabled = true;
                this_canvas.gameObject.SetActive(false);
                this_canvas.enabled = false;
            }
        }
        
        terminal_panel.text = "";
        foreach (var command in outnput_console_list)
        {
            terminal_panel.text += command;
        }
    }
}

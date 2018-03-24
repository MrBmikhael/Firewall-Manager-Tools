using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetFwTypeLib;
using System.Collections;

namespace FirewallInterface
{
    public class Firewall
    {
        private Type tNetFwPolicy2 = null;
        private INetFwPolicy2 fwPolicy2 = null;

        public enum RuleAction
        {
            ALLOW = 1,
            BLOCK = 0
        }

        public enum RuleDirection
        {
            Inbound = 1,
            Outbound = 2
        }

        public enum RuleProtocol
        {
            TCP = 6,
            UDP = 17,
            ANY = 256
        }

        public Firewall()
        {
            tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
        }

        public void ToggleAction(string ruleName)
        {
            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(ruleName) != -1)
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                    if (firewallPolicy.Rules.Item(ruleName).Action == NET_FW_ACTION_.NET_FW_ACTION_ALLOW)
                        firewallPolicy.Rules.Item(ruleName).Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    else
                        firewallPolicy.Rules.Item(ruleName).Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                }
            }
        }

        public void addRule(string path, RuleAction ruleAction, RuleDirection ruleDir, RuleProtocol ruleProtoc)
        {
            string appName = path;
            INetFwRule2 inboundRule = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
            inboundRule.Enabled = true;
            inboundRule.ApplicationName = appName;

            inboundRule.Protocol = (int)ruleProtoc;
            //inboundRule.Protocol = Convert.ToInt16(NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY);
            inboundRule.Direction = (NET_FW_RULE_DIRECTION_)ruleDir;
            //inboundRule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
            inboundRule.Profiles = 7;
            inboundRule.Name = "_BM_FW_" + ((int)ruleDir).ToString() + ((int)ruleAction).ToString() + ((int)ruleProtoc).ToString() + "_" + appName.Substring(appName.LastIndexOf(@"\") + 1, appName.Length - appName.LastIndexOf(@"\") - 5);
            inboundRule.Action = (NET_FW_ACTION_)ruleAction;
            //inboundRule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            firewallPolicy.Rules.Add(inboundRule);
        }

        public void deleteRule(string ruleName)
        {
            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(ruleName) != -1)
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Remove(rule.Name);
                }
            }
        }

        public List<string[]> loadRules(bool Glasswire = false)
        {
            List<string[]> RulesList = new List<string[]>();
            List<INetFwRule> RuleList = new List<INetFwRule>();
            string prefix = "_BM_FW_";

            if (Glasswire)
                prefix = "{Glasswire";

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(prefix) != -1)
                {
                    RulesList.Add(new string[] 
                    {
                        rule.Name,
                        rule.Action.ToString().Substring(rule.Action.ToString().LastIndexOf("_")+1),
                        rule.Direction.ToString().Substring(rule.Direction.ToString().LastIndexOf("_")+1) + "BOUND",
                        rule.ApplicationName
                    });
                }
            }

            return RulesList;
        }

        public void ToggleDirection(string ruleName)
        {
            List<INetFwRule> RuleList = new List<INetFwRule>();

            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(ruleName) != -1)
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

                    if (firewallPolicy.Rules.Item(ruleName).Direction == NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN)
                        firewallPolicy.Rules.Item(ruleName).Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                    else
                        firewallPolicy.Rules.Item(ruleName).Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                }
            }
        }
    }
}

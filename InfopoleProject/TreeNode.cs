using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace InfopoleProject
{
    public class TreeNode
    {
        public int Id { get; private set; } 
        public string Name { get; private set; } //имя узла
        public int ParentId { get; private set; } //ID родительского узла
        public List<TreeNode> Children { get; set; } //список дочерних узлов
        public string ShortName { get; private set; } //короткое имя узла
        //Cписок топа запросов Key - название запроса, value - частота
        public IEnumerable<KeyValuePair<string,int>> TopRequests { get; private set; } 
        [JsonIgnore]
        public TreeNode Parent { get; private set; } //родительский узел
        //Cписок запросов Key - название запроса, value - частота
        [JsonIgnore]
        public Dictionary<string, int> Requests { get; set; } 
        private long area; //площадь
        public long Area
        {
            get
            {
                if (area == 0)
                {
                    if (Children.Count == 0)
                    {
                        area = (from d in Requests select d.Value).Sum(); 
                    }
                    else
                    {
                        area = (from ch in Children select ch.Area).Sum();
                    }
                }
                return area;
            }
        }
        public TreeNode(TreeNode parent, int id, string shortName) 
        {
            Parent = parent;
            Id = id;
            if (parent != null)
            {
                ParentId = parent.Id;
            }
            ShortName = shortName;
            Requests = new Dictionary<string, int>();
            Children = new List<TreeNode>();
            if (parent == null)
            {
                Name = shortName;
            }
            else
            {
                parent.Children.Add(this);
                Name = parent.ShortName + "." + shortName;
            }
        }
        //добавление запроса в узел
        public void AddRequestToNode(string request,int phraseFreq, int accurateFreq) 
        {
            int freq = accurateFreq == 0 ? phraseFreq : accurateFreq;
            if (!Requests.ContainsKey(request))
            {
                Requests.Add(request, freq);
            }
            else if(Requests[request]<freq)
            {
                Requests[request] = freq;
            }
        }

        //Топ N запросов узла
        public IEnumerable<KeyValuePair<string,int>> GetTopRequests(int count)
        {
            if (Children.Count==0)
            {
                TopRequests = Requests.OrderByDescending(x => x.Value).Take(count);
                return TopRequests;
            }
            else
            {
                IEnumerable<KeyValuePair<string, int>> mergeList = new List<KeyValuePair<string, int>>();
                foreach(var child in Children)
                {
                    mergeList = mergeList.Concat(child.GetTopRequests(count)).ToList();
                }
                TopRequests = mergeList.OrderByDescending(x => x.Value).Take(count);
                return TopRequests;
            }
        }
        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;
            return node != null &&
                   Id == node.Id &&
                   Name == node.Name &&
                   ParentId == node.ParentId &&
                   Children.SequenceEqual(node.Children) &&
                   ShortName == node.ShortName;

        }   
    }
}

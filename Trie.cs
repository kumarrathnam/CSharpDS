public class TrieNode
    {
        public bool IsWordEnd {get; set;}
        Dictionary<char, TrieNode> nextNodeDict;
        
        public TrieNode() {
            this.nextNodeDict = new Dictionary<char, TrieNode>();
        }
        
        public TrieNode GetNode (char c, bool insertIfMissing = false) {
            
            TrieNode nextNode = null;
            
            if (this.nextNodeDict.ContainsKey(c)) {
                return this.nextNodeDict[c];
            }
            else if (insertIfMissing) {
                this.nextNodeDict[c] = new TrieNode();
                return this.nextNodeDict[c];
            }
            
            return nextNode;
        }
    }
    
    public class Trie {
        
        public TrieNode rootNode;
        
        public Trie() {
            this.rootNode = new TrieNode();
        }
        
        public void Add(string word) {
            
            var currentNode = this.rootNode;
            
            foreach (char c in word) {
                currentNode = currentNode.GetNode(c, true);
            }
            
            // End of word.
            currentNode.IsWordEnd = true;
        }
        
        public bool IsPrefix(string word) {
            var currentNode = this.rootNode;
            
            foreach (char c in word) {
                currentNode = currentNode.GetNode(c, false);
                
                if (currentNode == null) {
                    return false;
                }
            }
            
            return currentNode != null;
        }
        
        public bool IsWord(string word) {
            var currentNode = this.rootNode;
            
            foreach (char c in word) {
                currentNode = currentNode.GetNode(c, false);
                
                if (currentNode == null) {
                    return false;
                }
            }
            
            return currentNode != null && currentNode.IsWordEnd;
        }
    }

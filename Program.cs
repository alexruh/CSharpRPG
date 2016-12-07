using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ello!");
            var myCharacter = new character();
            for (int i = 0; i < 105; i++)
            {
                myCharacter.decLevel();
            }
            myCharacter.printDiag();
            Console.ReadKey();
        }
    }

    public class character
    {
        //types, skills
        public enum type { Warrior, Wizard, Merchant, Alchemist, Unknown };

        //character specs
        private type thisType;
        private int level;
        private int health;
        private int mana;
        private List inventory;

        //constructors 
        public character()
        {
            thisType = type.Unknown;
            level = 0;
            health = 10;
            mana = 2;
            inventory = new List();
        }

        //Accessors
        public type viewType()
        {
            return this.thisType;
        }
        public int viewLevel()
        {
            return this.level;
        }
        public int viewHealth()
        {
            return this.health;
        }
        public int viewMana()
        {
            return this.mana;
        }

        //Mutators
        //direct
        public bool changeType(type aType)
        {
            this.thisType = aType;
            if (this.thisType == aType) return true;
            else return false;
        }
        public bool changeLevel(int aLevel)
        {
            this.level = aLevel;
            if (this.level == aLevel) return true;
            else return false;
        }
        public bool changeHealth(int aHealth)
        {
            this.health = aHealth;
            if (this.health == aHealth) return true;
            else return false;
        }
        public bool changeMana(int aMana)
        {
            this.mana = aMana;
            if(this.mana == aMana) return true;
            else return false;
        }
        //indirect
        public bool incLevel()
        {
            if (this.level < 100 && this.level >= 0)
            {
                this.level++;
                return true;
            }
            else return false;
        }
        public bool decLevel()
        {
            if (this.level <= 100 && this.level > 0)
            {
                this.level--;
                return true;
            }
            else return false;
        }

        //diagnostic
        public void printDiag()
        {
            type buf = this.viewType();
     //       Enum.TryParse(this.viewType(), buf);
            Console.WriteLine("Type: {0}\nLevel: {1}\nHealth: {2}\nMana: {3}\n",buf.ToString(),this.viewLevel(),this.viewHealth(),this.viewMana());
        }

    }

    public class item
    {
        public enum itemClassTypes {Weapon, Clothing}

        private itemClassTypes itemClass;
        private string name;

        public item(itemClassTypes aType, string aName)
        {
            name = aName;
            itemClass = aType;
        }
    }

    public class List
    {
        public class Node
        {
            public object NodeContent;
            public Node next;
        }

        private int size;
        public int Count
        {
            get
            {
                return size;
            }
        }

        //head
        private Node head;
        private Node current;

        public List()
        {
            size = 0;
            head = null;
        }

        public void Add(object content)
        {
            size++;
            var node = new Node()
            {
                NodeContent = content
            };

            if (head == null)
            {
                head = node;
            }
            else
            {
                current.next = node;
            }

            current = node;
        }

        public void ListNodes()
        {
            Node tempNode = head;
            while (tempNode != null)
            {
                Console.WriteLine(tempNode.NodeContent);
                tempNode = tempNode.next;
            }
        }
        public Node Retrieve(int Position)
        {
            Node tempNode = head;
            Node retNode = null;
            int count = 0;

            while (tempNode != null)
            {
                if (count == Position - 1)
                {
                    retNode = tempNode;
                    break;
                }
                count++;
                tempNode = tempNode.next;
            }

            return retNode;
        }
        public bool Delete(int Position)
        {
            if (Position == 1)
            {
                head = null;
                current = null;
                return true;
            }

            if (Position > 1 && Position <= size)
            {
                Node tempNode = head;

                Node lastNode = null;
                int count = 0;

                while (tempNode != null)
                {
                    if (count == Position - 1)
                    {
                        lastNode.next = tempNode.next;
                        return true;
                    }
                    count++;

                    lastNode = tempNode;
                    tempNode = tempNode.next;
                }
            }

            return false;
        }
    }
}

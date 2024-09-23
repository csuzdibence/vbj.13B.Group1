namespace VBJ._13B.Group1.OOPGyakorlo1
{
    public class Prison
    {
        private static int idIndex = 0;
        Prisoner[] prisoners;
        public Prison(int size)
        {
            prisoners = new Prisoner[size];
        }

        public bool AddPrisoner(Prisoner prisoner)
        {
            for (int i = 0; i < prisoners.Length; i++)
            {
                if (prisoners[i] is null)
                {
                    prisoners[i] = prisoner;
                    return true;
                }
            }
            return false;
        }

        public string PrisonerList()
        {
            string text = string.Empty;
            foreach (var prisoner in prisoners)
            {
                text += (prisoner.PrisonerText+ "\n");
            }
            return text;
        }

        public void Escape()
        {
            for (int i = 0; i < prisoners.Length; i++)
            {
                if (prisoners[i] is null)
                {
                    continue;
                }

                if (prisoners[i].Smartness > 50)
                {
                    prisoners[i] = null;
                }
                else 
                {
                    prisoners[i].Smartness += 5;
                }
            }
        }
    }
}

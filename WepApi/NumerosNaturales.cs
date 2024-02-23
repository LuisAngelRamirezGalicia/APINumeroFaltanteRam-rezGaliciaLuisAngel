namespace WepApi
{
    public class NumerosNaturales
    {
        public List<int>? Numeros {  get; set; }
       
        public void Extract (int numeroExtraer)
        {
            Numeros.RemoveAt(numeroExtraer);

        }

        public int CualSeExtrajo()
        {  
            
            int extraido = 0;
            int temporal = 0;
            foreach(int i in Numeros)
            {
                temporal = temporal + i;
            }
            //4950 es los primeros 100 numeros sumados del 0 al 99

            extraido = 4950 - temporal;
            return extraido;
        }





    }
}

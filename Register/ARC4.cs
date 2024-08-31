namespace iHuya
{
    public class ARC4
    {
        private int int_0;

        private int int_1;

        private byte[] byte_0;

        public ARC4(byte[] key = null, bool d = false)
        {
            if (key != null)
            {
                byte_0 = new byte[256];
                init(key);
                if (d)
                {
                    init(key);
                }
            }
        }

        public void init(byte[] key)
        {
            for (int i = 0; i < 256; i++)
            {
                byte_0[i] = (byte)i;
            }
            int num = 0;
            for (int i = 0; i < 256; i++)
            {
                num = ((num + byte_0[i] + key[i % key.Length]) & 0xFF);
                int num2 = byte_0[i];
                byte_0[i] = byte_0[num];
                byte_0[num] = (byte)num2;
            }
            int_0 = 0;
            int_1 = 0;
        }

        public void encrypt(byte[] block)
        {
            int num = 0;
            while (num < block.Length)
            {
                int num3 = num++;
                block[num3] = (byte)(block[num3] ^ next());
            }
        }

        public void decrypt(byte[] bytes)
        {
            encrypt(bytes);
        }

        public uint next()
        {
            int_0 = ((int_0 + 1) & 0xFF);
            int_1 = ((int_1 + byte_0[int_0]) & 0xFF);
            int num = byte_0[int_0];
            byte_0[int_0] = byte_0[int_1];
            byte_0[int_1] = (byte)num;
            return byte_0[(num + byte_0[int_0]) & 0xFF];
        }
    }
}

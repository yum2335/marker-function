using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ボタン受信
{
    class sousarireki
    {
        
        public void sousa()
        {
            int x = System.Windows.Forms.Cursor.Position.X;
            
            int y = System.Windows.Forms.Cursor.Position.Y;

            using (StreamWriter sw = new StreamWriter(@"C:\被験者5\8.txt", true, Encoding.UTF8))
                sw.WriteLine(DateTime.Now + " x座標 = {0}, y座標 = {1}", x, y);
        }

        public void marker(int c,int i,int k)
        {
            int x = System.Windows.Forms.Cursor.Position.X;

            int y = System.Windows.Forms.Cursor.Position.Y;

            using (StreamWriter sw = new StreamWriter(@"C:\被験者5\8.txt", true, Encoding.UTF8))
                sw.WriteLine(DateTime.Now + " マーカー{0},x座標 = {1}, y座標 = {2}",c, i,k );
        }

        public void deletemarker(int s)
        {
            int x = System.Windows.Forms.Cursor.Position.X;

            int y = System.Windows.Forms.Cursor.Position.Y;

            using (StreamWriter sw = new StreamWriter(@"C:\被験者5\8.txt", true, Encoding.UTF8))
                sw.WriteLine(DateTime.Now + " マーカー{0}削除",s);
        }
        
    }
    
}

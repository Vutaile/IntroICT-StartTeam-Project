/*
 * Ho ten: Vo Le Anh Tai
 * Ngay: 29/11/2023
 * Tom tat: Nhap so nguyen N (1<=N<=100), nhap mang, xuat mang, xuat so chan, xuat so nguyen to trong mang va cac yeu cau khac
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VoLeAnhTai_KTLT_Ch7_Cau1
{
    internal class VoLeAnhTai_KTLT_Ch7_Cau1
    {
        static void Main(string[] args)
        {
        //Khai bao
            int Num = 0;
            int SoX = 0;
            int[] Arr = new int[1000000];
            int[] ArrTang = new int[1000000];

        //Nhap
            nhapSoNguyen1Den100(ref Num);
            nhapSoNguyen(ref SoX);

            //Cau A
            Arr = nhapMang1Chieu(Num);
            
        //Xuat
            
            //Cau B
            Console.WriteLine();
            xuatMang(Arr);
            
            //Cau C
            Console.WriteLine();
            xuatChan(Arr);
            
            //Cau D (Xuat cac so nguyen to co trong mang)
            Console.WriteLine();
            xuatSNT(Arr);
            
            //Cau E
            Console.WriteLine();
            Console.WriteLine($"Cau E: Trung binh cong cac phan tu trong mang = {tinhTrungBinhCong(Arr)}");
            
            //Cau F
            Console.WriteLine();
            Console.WriteLine($"Cau F: So luong so hoan thien trong mang = {demHoanHao(Arr)}");
            
            //Cau G
            Console.WriteLine();
            if (findLastPlace(Arr, SoX) == -1)
            {
                Console.WriteLine($"Cau G: Khong co phan tu {SoX} trong mang");
            }
            else 
            {
                Console.WriteLine($"Cau G: Vi tri cuoi cung cua phan tu {SoX} trong mang = {findLastPlace(Arr, SoX)}"); 
            }
            
            //Cau H
            Console.WriteLine();
            if (findFirstSNT(Arr) == -1)
            {
                Console.WriteLine($"Cau H: Khong co so nguyen to trong mang");
            }
            else 
            {
                Console.WriteLine($"Cau H: Vi tri so nguyen to dau tien trong mang = {findFirstSNT(Arr)}"); 
            }
            
            //Cau I
            Console.WriteLine();
            Console.WriteLine($"Cau I: Phan tu lon nhat trong mang = {findMax(Arr)}");
            
            //CauJ
            Console.WriteLine();
            if (findMinDuong(Arr) <= 0)
            {
                Console.WriteLine("Cau J: Mang khong co so nguyen duong");
            }
            else
            {
                Console.WriteLine($"Cau J: Phan tu nguyen duong nho nhat trong mang = {findMinDuong(Arr)}");
            }
            Console.WriteLine();

            //Cau K
            ArrTang = sapXepTang(Arr);
            Console.WriteLine("Cau K: Mang sau khi sap xep tang dan:");
            for (int i=0; i<ArrTang.Length; i++)
            {
                Console.WriteLine($"Arr[{i}] = {ArrTang[i]}");
            }
            Console.WriteLine();

            //Cau L
            if (kiemtraThuTuTang(Arr) == true)
            {
                Console.WriteLine("Cau L: Mang co thu tu tang dan");
            }
            else
            {
                Console.WriteLine("Cau L: Mang khong co thu tu tang dan");
            }

            Console.ReadKey();
        }

        //Ham nhap 1 so nguyen tu 1 den 100
        public static void nhapSoNguyen1Den100(ref int Num)
        {
            do
            {
                Console.Write("Nhap 1 so nguyen tu 1 den 100 = ");
                int.TryParse(Console.ReadLine(), out Num);
            } while (Num<1 || Num>100);
        }

        //Ham nhap so nguyen
        public static void nhapSoNguyen(ref int Num)
        {
            Console.Write("Nhap 1 so nguyen = ");
            int.TryParse(Console.ReadLine(), out Num);
        }

        //Ham nhap mang co chieu dai N (Cau A)
        public static int[] nhapMang1Chieu(int Num)
        {
            int[] Arr = new int[Num];
            Console.WriteLine("Cau A: Mang co cac phan tu sau:");
            for (int i=0; i<Arr.Length; i++)
            {
                int.TryParse(Console.ReadLine() , out Arr[i]);
            }
            return Arr;
        }

        //Ham xuat mang (Cau B)
        public static void xuatMang(int[] Arr)
        {
            Console.WriteLine("Cau B: Danh sach tat ca phan tu trong mang Arr:");
            for (int i=0; i<Arr.Length; i++)
            {
                Console.WriteLine($"Arr[{i}] = {Arr[i]}");
            }
        }

        //Ham xuat cac so chan trong mang (Cau C)
        public static void xuatChan(int[] Arr)
        {
            Console.WriteLine("Cau C: Danh sach phan tu chan trong mang Arr:");
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i] % 2 == 0)
                {
                    Console.WriteLine($"Arr[{i}] = {Arr[i]}");
                }
            }
        }

        //Ham kiem tra snt
        public static bool kiemTraSNT(int Num)
        {
            bool KetQua = true;
            if (Num<=1)
            {
                KetQua = false;
            }
            else if (Num >= 2)
            {
                for (int i = 2; i <= Num / 2; i++)
                {
                    if (Num % i == 0)
                    {
                        KetQua = false;
                        break;
                    }
                }
            }
            return KetQua;
        }

        //Ham xuat so nguyen to (Cau D)
        public static void xuatSNT(int[] Arr)
        {
            Console.WriteLine("Cau D: Danh sach so nguyen to trong mang Arr:");
            for (int i = 0; i < Arr.Length; i++)
            {
                if (kiemTraSNT(Arr[i]) == true)
                {
                    Console.WriteLine($"Arr[{i}] = {Arr[i]}");
                }
            }
        }

        //Ham tinh trung binh cong cac phan tu trong mang (Cau E)
        public static double tinhTrungBinhCong(int[] Arr)
        {
            double Tong = 0;
            double Average = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                Tong += Arr[i];
            }
            Average = Tong / Arr.Length;
            return Average;
        }

        //Ham kiem tra so hoan hao (so hoan thien)
        public static bool kiemTraHoanHao(int Num)
        {
            bool KetQua = true;
            int Tong = 0;
            for (int i = 1; i <= Num / 2; i++)
            {
                if (Num % i == 0)
                {
                    Tong += i;
                }
            }
            if (Tong != Num || Num <= 0)
            {
                KetQua = false;
            }
            return KetQua;
        }

        //Ham dem so luong so hoan hao (so hoan thien) co trong mang (Cau F)
        public static int demHoanHao(int[] Arr)
        {
            int Dem = 0;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (kiemTraHoanHao(Arr[i]) == true)
                {
                    Dem++;
                }
            }
            return Dem;
        }

        //Ham tim vi tri cuoi cung cua phan tu X trong mang (Cau G)
        public static int findLastPlace(int[] Arr, int SoX) 
        {
            int Last = -1;
            for (int i = Arr.Length-1; i >= 0; i--)
            {
                if (Arr[i] == SoX) 
                {
                    Last = i;
                    break;
                }
            }
            return Last;
        }

        //Ham tim so nguyen to dau tien trong mang (Cau H)
        public static int findFirstSNT(int[] Arr)
        {
            int First = -1;
            for (int i = 0; i < Arr.Length; i++)
            {
                if (kiemTraSNT(Arr[i]) == true)
                {
                    First = i;
                    break;
                }
            }
            return First;
        }

        //Ham tim phan tu lon nhat trong mang (Cau I)
        public static int findMax(int[] Arr)
        {
            int Max = Arr[0];
            for (int i = 1; i < Arr.Length; i++)
            {
                if (Arr[i] > Max)
                {
                    Max = Arr[i];
                }
            }
            return Max;
        }

        //Ham tim so duong nho nhat trong mang (Cau J)
        public static int findMinDuong(int[] Arr)
        {
            int Min = Arr[0];
            for (int i = 1; i < Arr.Length; i++)
            {
                if (Arr[i] < Min && Arr[i] > 0)
                {
                    Min = Arr[i];
                }
            }
            return Min;
        }

        //Ham sap xep cac phan tu cua mang tang dan (Cau K)
        public static int[] sapXepTang(int[] Arr)
        {
            int[] Arr1 = new int[Arr.Length];
            for (int i = 0; i < Arr.Length; i++)
            {
                Arr1[i] = Arr[i];
            }

            int Temp = 0;
            for (int i=0; i<Arr1.Length; i++)
            {
                for (int j=0; j<Arr1.Length; j++)
                {
                    if (Arr1[i] < Arr1[j])
                    {
                        Temp = Arr1[i];
                        Arr1[i] = Arr1[j];
                        Arr1[j] = Temp;
                    }
                }
            }
            return Arr1;
        }

        //Ham kiem tra thu tu tang dan (Cau L)
        public static bool kiemtraThuTuTang(int[] Arr)
        {
            bool KetQua = true;
            for (int i=1; i<Arr.Length; i++)
            {
                if (Arr[i] < Arr[i-1])
                {
                    KetQua = false;
                    break;
                }
            }
            return KetQua;
        }
    }
}

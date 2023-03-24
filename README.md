# Tubes2-mrKrrabs' Krusty Treasure
 Project ini dibuat oleh Akbar Maulana Ridho (13521093), Nathania Callista (13521139), dan Alisha Listya Wardhani (13521171) yang merupakan salah satu pemenuhan Tugas Kecil I IF2211 Strategi Algoritma:
<h2 align="center">
  Krusty Treasure <br/>
</h2>

<p align="center">
<img width="1277" alt="Screen Shot 2023-03-24 at 14 21 01" src="https://user-images.githubusercontent.com/73476678/227535048-191243f6-cf50-4dce-9927-08d81d7b002b.png">

</p>
<p> Program ini merupakan desktop app program yang dibuat dengan bahasa C#. Pada program ini, pengguna dapat memasukkan textfile berisi konfigurasi peta. Di dalam peta tersebut terdapat posisi awal (K), posisi _treasure_ (T), Tunnel (R) dan Dirt (X). Kemudian, pengguna dapat memilih algoritma DFS (Depth-First-Search) ataupun BFS (Breadth-First-Search) untuk menemukan rute yang mengambil semua _treasure_. Pada program ini juga diimplementasikan permasalahan Travelling Salesman Problem (TSP) shingga pengguna dapat kembali ke posisi awal. </p>
<hr> 

## Features
Berikut merupakan fitur dari program kami:
* Visualisasi Pencarian Rute secara Real-time
* Slider untuk menyesuaikan waktu interval visualisasi rute
* Toggle untuk mengaktifkan penyelesaian TSP
* Button untuk memilih antara algoritma BFS atau DFS

## Table of Contents
1. [Getting Started](#getting-started)
2. [How to Run](#how-to-run)
3. [Struktur](#struktur)
4. [Tampilan Program](#tampilan)

<a name="getting started"></a>

## Getting Started!

Berikut merupakan cara untuk build project atau menginstall program

1. Clone repo menggunakan command berikut

```
git clone https://github.com/akbarmridho/Tubes2_mrKrrabs.git
```

2. Setelah masuk ke folder program, jalankan perintah berikut untuk compile program utama!

Untuk windows:
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```
Untuk LINUX:
```
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
Untuk MACOS:
```
dotnet publish -c Release -r osx-x64 --self-contained true -p:PublishSingleFile=true
```

## How-to-Run

Bagaimana cara menjalankan program? Gunakan command berikut pada folder program untuk menjalankan program utama

```
bin/mrKrrabs
```
Kami juga menyediakan build yang sudah dapat Anda gunakan langsung. Pada folder bin, terdapat executable zip untuk MACOS dan Windows. Unzip file yang sesuai dengan sistem operasi kamu, dan jalankan file mrKrrabs! Setelah itu, ikuti petunjuk pada program. Ingat bahwa textfile yang diterima hanyalah txt yang berisi 'K', 'X', 'R' dan 'T' :)

     
<a name="tampilan"></a>
## Tampilan Program
<img width="1276" alt="Screen Shot 2023-03-24 at 12 57 07" src="https://user-images.githubusercontent.com/73476678/227537926-f804b7ec-857c-4df9-ab22-eabfa2db70e6.png">
<img width="1277" alt="Screen Shot 2023-03-24 at 14 05 46" src="https://user-images.githubusercontent.com/73476678/227537942-85da3c4c-590e-4456-95b9-281871302033.png">
<img width="1276" alt="Screen Shot 2023-03-24 at 14 53 40" src="https://user-images.githubusercontent.com/73476678/227537984-c4da46c6-c1fc-48ed-85f3-7324e92b261c.png">


<a name="author"></a>

## Author
<h4 align="center">
    Created by mr.Krrabs<br/>
    K1 / 2023
</h4>
<hr>

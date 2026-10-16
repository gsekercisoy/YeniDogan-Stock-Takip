<div align="center">

[English](README.md) | **Türkçe**

# YeniDoğan Stok Takip

Lokum/helva üretim fabrikası için yazılmış C# WinForms stok-satış takip programı:
alım, satış fişi, iade, müşteri, gider ve kâr/zarar raporlama.

</div>

## Özellikler

- Mal alımı ve alım fişleri → stoğa giriş
- Satış fişi kesme/silme, günlük satış ekranları
- İade işlemleri (işlem + fiş + portföy)
- Müşteri yönetimi (liste / ekle / detay / bakiye portföyü)
- Gider takibi ve iadeler düşülmüş kâr/zarar raporu
- Merkezi `vt.cs` veri erişim yardımcısı (şifresiz Jet/ACE bağlantı)

## Teknolojiler

- C# WinForms, .NET Framework 4.8 (VS 2017 solution)
- MS Access veritabanı (`gelir.mdb`, `System.Data.OleDb`) — config'de şifre yok
- NuGet bağımlılığı yok

## Çalıştırma (Windows)

1. `YENİDOĞAN V3.sln` dosyasını Visual Studio ile açıp derle (`Debug | AnyCPU`)
2. `gelir.mdb` veritabanını exe'nin yanına koy (`bin\Debug\`)
   (32-bit Jet OLEDB; 64-bit ACE yoksa x86 hedefle)
3. Çalıştır — uygulama `Form1` menüsünden açılır

## Yapı

```
YENİDOĞAN V3/
  Form1.cs            # ana menü
  alım.cs, alımfis.cs # satın alma
  fis.cs, fissil.cs, gunluk.cs, GÜNLÜK.cs  # satış
  iade*.cs            # iadeler
  musteri*.cs         # müşteriler
  stok.cs, ürünara.cs, duzenleme.cs  # stok/ürün
  gider.cs, raporlama.cs, rutform.cs # finans/rapor
  vt.cs               # DB yardımcısı (Baglan/dtGetir/sqlCalistir)
kutuphane.dll         # paylaşılan yardımcı kütüphane
```

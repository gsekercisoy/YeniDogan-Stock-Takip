<div align="center">

**English** | [Türkçe](README_tr.md)

# YeniDogan Stock Tracking

C# WinForms stock-and-sales tracking program built for a lokum/helva factory:
purchasing, sales receipts, returns, customers, expenses and profit reporting.

</div>

## Features

- Purchase entry and purchase receipts → stock in
- Sales receipts, receipt deletion, daily sales screens
- Returns (process + receipt + portfolio)
- Customer management (list / add / detail / balance portfolio)
- Expense tracking and profit/loss reporting (net of returns)
- Central `vt.cs` data-access helper (Jet/ACE, parameterized patterns)

## Tech stack

- C# WinForms, .NET Framework 4.8 (VS 2017 solution)
- MS Access database (`gelir.mdb`, via `System.Data.OleDb`) — no passwords in config
- No NuGet dependencies

## Getting started (Windows)

1. Open `YENİDOĞAN V3.sln` in Visual Studio and build (`Debug | AnyCPU`)
2. Place the `gelir.mdb` database file next to the built exe (`bin\Debug\`)
   (32-bit Jet OLEDB; use x86 target if the 64-bit ACE provider is missing)
3. Run — the app starts at the `Form1` menu

## Structure

```
YENİDOĞAN V3/
  Form1.cs            # main menu
  alım.cs, alımfis.cs # purchasing
  fis.cs, fissil.cs, gunluk.cs, GÜNLÜK.cs  # sales
  iade*.cs            # returns
  musteri*.cs         # customers
  stok.cs, ürünara.cs, duzenleme.cs  # stock/products
  gider.cs, raporlama.cs, rutform.cs # finance/reports
  vt.cs               # DB helper (Baglan/dtGetir/sqlCalistir)
kutuphane.dll         # shared helper library
```

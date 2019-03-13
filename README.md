# APPPInCSharp_CoffeeMakerAPI

無瑕的程式碼 : 物件導向原則、設計模式與C#實踐 Agile Principles, Patterns, and Practices in C#

## Solution

* 關注問題的根本: 如何煮咖啡?
  * 將熱水倒在研磨好的咖啡上 (HotWaterSource)
  * 把沖泡好的咖啡液體收集在某種器皿中 (ContainmentVessel)
  * 與系統互動 (UserInterface)

## Use Case

### 1.使用者按下了沖煮按鈕

* 確保
  * 熱水器加滿水
  * 咖啡壺是空的，並且放在保溫盤上

* 關閉閥門，開啟熱水器

### 2.接收器皿沒有準備好

* ContainmentVessel需要能
  * 通知HotWaterSource停止傳送熱水
  * 通知HotWaterSource再次啟動熱水流

### 3.沖煮完成

* HotWaterSource/ContainmentVessel都可發送完成訊息

### 4.咖啡喝完了

* ContainmentVessel發送完成訊息給UserInterface
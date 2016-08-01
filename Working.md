# 工作文件複本
## 成員
* 黨
* Ray
* 橘之介
* 5a
* Siyuan
* 洪子凡 (Hubert)

## 概要
改變遊戲背景，但主角在畫面中的大小不變。以這個特點來進行解謎


點擊畫面，角色開始前進，再點一次角色停止（目前改成不停止往前）
角色與地板在最前面一層
只有在角色停止時才能操作slider（目前角色不停止）
拖曳slider，讓背景層改變
zoom in/out
rotate：以攝影機中心為轉動軸（沒時間完成，移除）
move
依照關卡的功能，slider可能是以上3（沒有rotate）種任一種
最多3個slider，可能是同一層的不同功能，或分別控制不同層（Layer機制不確定，可能無法出來）
場景物件：

## 素材

* 鎖住的門(art)
* 門可通往下一關的提示(在門上閃爍)
* 主角(art)    
* 通道-傳送門
* checkpoint-切scene，每一小關的終點
* 鑰匙   
* 可分成一塊塊的石頭地板   
* 牆壁   
* 樓梯    
* 繩梯    
* 地板(循環)    
* 障礙物    
* 轉動木板
* 史萊姆：不會隨著操作變化，會吸住鑰匙   
* 石像：只能放大，放大後角色從兩腿之間通過(art)   
* 稻草人：不會隨著操作變化，會被火燒掉，會有被火燒到的感覺可參考此
* 砲彈：縮小之後就沒有傷害（不確定可否加入）
* 月亮拼圖：利用縮放、移動、轉動來拼成完整圖案（來不及則移除）
* 火把：上面的火會用來做放大、縮小，可以燒掉稻草人（來不及，移除）
* 水    
* 裝飾品    

## 關卡
關卡編輯摘要

### room1: 

layer1: zoom in

### room2: 

layer1: zoom in/out
red slime

### room3: 

layer1: zoom in/out, 
layer2: zoom in/out
red slime
scarecrow

### room4: 

layer1: move up/down
red slime
scarecrow

### room5: 

layer1: move up/down, 
layer2: left/right
red slime
scarecrow
Stone Giant（放大後從跨下過去會是重點）

### room6: （沒時間做，移除）

layer1: move up/down, 
layer2: move up/down, 
layer3: move up/down

### room7: （沒時間做，移除）

layer1: move up/down, 
layer2: move left/right, 
layer3: zoom in/out

### room8: （沒時間做，移除）

layer1: zoom, 
layer2: zoom, 
layer3: move up/down

### room9: （沒時間做，移除）

layer1:rotate, 
layer2: rotate, 
layer3: rotate

### room10: （沒時間做，移除）

layer1: zoom, 
layer2: move up/down, 
layer3: rotate

## 其他

關卡編輯時的怪物碰撞來回機制需要做嚐試。


## Git 目錄
https://github.com/twsiyuan/fgj-2016



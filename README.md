# GovernmentBidding
火箭隊爬蟲作業-招標網站

本次題目為寫console程式，電子採購網爬當天的資料，可在App.config 設定關鍵字，案件包含關鍵字需記信通知(通知人在App.config 設定)，且放到資料庫，要用.net Entity Framework 建model 寫入資料庫
網站為：https://web.pcc.gov.tw/tps/pss/tender.do?searchMode=common&searchType=basic&method=search&isSpdt=&pageIndex=12

於app.config可以設定關鍵字及寄信收信帳號

最近政府有在防範攻擊，故需要寫Delay(尚未新增)，不然就需要認證，嚴重會被鎖IP。

後續須由研究排程，每天自動啟動。

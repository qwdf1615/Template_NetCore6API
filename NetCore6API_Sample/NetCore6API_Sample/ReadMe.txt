
// 想測試流程的可以將 Models資料夾、Data資料夾 內的檔案刪除

1. Code First 流程 (SQLite)
	> 建立 Table Model (Models資料夾裡面) _ 建立資料表與欄位
	> 建立 DBContext (Data/SampleDBContext.cs) 
	> AddDbContext擴充方法 (Program.cs)
	> 輸入指令 Add Migration CreateDB -o Data/Migratioins
	> 上述完成後, 輸入 Update-Database (建立或更新DB)

* Migration 參考 https://docs.microsoft.com/zh-tw/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
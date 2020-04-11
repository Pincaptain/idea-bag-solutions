const sqlite3 = require('sqlite3').verbose();

export function initDatabase() {
    const database = new sqlite3.Database("database.db");
    database.run(`CREATE TABLE IF NOT EXISTS [Alarm] (
        [AlarmId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
        [AlarmTitle] NVARCHAR(255) NOT NULL,
        [AlarmDescription] TEXT,
        [AlarmMoment] DATETIME NOT NULL
    );`);
}
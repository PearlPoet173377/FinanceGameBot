using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace FinanceGameBot
{
    class FinGameDB
    {
        
        //////////////////
        ///Get Info from BD
        /////////////////
        ///
        public int GetLastId()
        {
            string sqlExpression = $"select id from Persons order by id desc limit 1";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public long GetPersonId(string ChatId)
        {
            int cId = Convert.ToInt32(ChatId);
            string sqlExpression = $"select chatid from Persons where id = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            long res = Convert.ToInt64(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public int GetPersonMoney(string ChatId)
        {
            int cId = Convert.ToInt32(ChatId);
            string sqlExpression = $"select money from Persons where chatid = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public string GetStockCount(string chatId)
        {
            int cId = Convert.ToInt32(chatId);
            string res = "";
            string sqlExpression = $"select MacrosoftStock from Persons where chatid = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            res += " ";
                            res += Convert.ToString(result);
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            string sqlExpression1 = $"select LamazonStock from Persons where chatid = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression1, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            res += " ";
                            res += Convert.ToString(result);
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            string sqlExpression2 = $"select GoogolStock from Persons where chatid = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression2, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            res += " ";
                            res += Convert.ToString(result);
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            string sqlExpression3 = $"select PersonBookStock from Persons where chatid = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression3, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            res += " ";
                            res += Convert.ToString(result);
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return res;
        }

        ////////////////////////
        ///GetPrice
        ///////////////////////
        public int GetCurrentPrice(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select currentprice from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public int GetOneRoundLaterPrice(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select oneroundlaterprice from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public int GetTwoRoundLaterPrice(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select tworoundlaterprice from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public int GetThreeRoundLaterPrice(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select threeroundlaterprice from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public int GetFourRoundLaterPrice(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select fourroundlaterprice from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public string GetCompName(string CompanieName)
        {
            int CompanieId = Convert.ToInt32(CompanieName);
            string sqlExpression = $"select name from CompaniesStock where id = {CompanieId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            string res = Convert.ToString(result);
                            return res;
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            return "";
        }

        /////////////////////////////
        /// Change Prices
        ////////////////////////////
        public void ChangeChangerCompPrice()
        {
            Random rnd = new Random();
            UpdateChanger(1, rnd.Next(1, 9));
            UpdateChanger(2, rnd.Next(1, 9));
            UpdateChanger(3, rnd.Next(1, 9));
            UpdateChanger(4, rnd.Next(1, 9));

        }

        public int GetChanger(int cId)
        {
            string sqlExpression = $"select changer from Changers where id = {cId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var result = reader.GetValue(0);
                            int res = Convert.ToInt32(result);
                            return res;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        public void UpdateChanger(int cId, int chng)
        {
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"update Changers set changer = {chng} where id = {cId}";
                command.ExecuteNonQuery();
            }
        }

        public string SendNews()
        {
            string txt = "Сводка новостей и прогнозы на следующий раунд:";
            for (int i = 1; i <= 4; i++)
            {
                string name = GetCompName(Convert.ToString(i));
                switch (GetChanger(i))
                {
                    case 1:
                        txt = txt + $"\n---------\n{i})Компания {name} выпустила новую продукцию. По предворительным данным её ожидает успех по продажам. Ожидается повышение цен на акции.";
                        break;
                    case 2:
                        txt = txt + $"\n---------\n{i})Компания {name} выпустила новую продукцию, которая показала средние продажи и оценки пользователей. Ожидается слабое повышение или небольшое понижение цен на акции.";
                        break;
                    case 3:
                        txt = txt + $"\n---------\n{i})Компания {name} выпустила новую продукцию. По предворительным данным она провалилась по продажам. Ожидается понижение цен на акции.";
                        break;
                    case 4:
                        txt = txt + $"\n---------\n{i})Компания {name} приобрела ещё одну компанию. Эксперты считают, что эта сделка крайне удачна. Ожидается повышение цен акций.";
                        break;
                    case 5:
                        txt = txt + $"\n---------\n{i})Компания {name} приобрела ещё одну компанию. Эксперты считают, что эта сделка - спорное решение. Ожидается слабое повышение или небольшое понижение цен на акции.";
                        break;
                    case 6:
                        txt = txt + $"\n---------\n{i})Компания {name} приобрела ещё одну компанию. Эксперты считают, что эта сделка - неудачный ход. Ожидается понижение цен на акции.";
                        break;
                    case 7:
                        txt = txt + $"\n---------\n{i})Компания {name} заявила о исследовании новой технологии. Тема, на которую проводится это исследование, является перспективной. Ожидается повышение цен акций.";
                        break;
                    case 8:
                        txt = txt + $"\n---------\n{i})Компания {name} заявила о исследовании новой технологии. Тема, на которую проводится исследование, крайне спорна, но имеет некоторые перспективы. Ожидается слабое повышение или небольшое понижение цен на акции.";
                        break;
                    case 9:
                        txt = txt + $"\n---------\n{i})Компания {name} заявила о исследовании новой технологии. Тема, на которую проводится исследование, не пользуется большим спросом. Ожидается понижение цен на акции";
                        break;
                }
            }
            
            return txt;
        }

        public int AlgForPrice(string CompanieId)
        {
            int cId = Convert.ToInt32(CompanieId);
            int cprice = GetCurrentPrice(CompanieId);
            Random rnd = new Random();
            int value;
            float changer;
            int res = cprice;
            if (cprice <= 10)
            {
                value = rnd.Next(1000, 2000);
                changer = (Convert.ToSingle(value)) / 1000;
                res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                return res;
            }
            if(cprice >=2500)
            {

                value = rnd.Next(750, 1000);
                changer = (Convert.ToSingle(value)) / 1000;
                res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                return res;
            }
            switch (GetChanger(cId))
            {
                case 1:
                    value = rnd.Next(950, 1300);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 2:
                    value = rnd.Next(850, 1150);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 3:
                    value = rnd.Next(700, 1050);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 4:
                    value = rnd.Next(950, 1300);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 5:
                    value = rnd.Next(850, 1150);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 6:
                    value = rnd.Next(700, 1050);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 7:
                    value = rnd.Next(950, 1300);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 8:
                    value = rnd.Next(850, 1150);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
                case 9:
                    value = rnd.Next(700, 1050);
                    changer = (Convert.ToSingle(value)) / 1000;
                    res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
                    break;
            }

            return res;
        }

        public void ChangePrices(string CompanieId)
        {
            int cId = Convert.ToInt32(CompanieId);
            int curprice = AlgForPrice(CompanieId);
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"update CompaniesStock set fourroundlaterprice = threeroundlaterprice, threeroundlaterprice = tworoundlaterprice, tworoundlaterprice = oneroundlaterprice, oneroundlaterprice = currentprice, currentprice = {curprice} where id = {cId}";
                command.ExecuteNonQuery();
            }
        }

        ////////////////////////////
        ///Add person
        ///////////////////////////
        public bool CheckPerson(long ChatId)
        {
            string sqlExpression = $"select new from persons where chatid = {ChatId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                        {
                        if (reader.GetValue(0) != DBNull.Value)
                        {
                            int res = Convert.ToInt32(reader.GetValue(0));
                            if (res == 1)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                    return true;
                }
            }
        }

        public void AddPerson(long ChatId)
        {
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();

                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                bool check = CheckPerson(ChatId);
                if(check)
                {
                    command.CommandText = $"insert into Persons(chatid, new) values({ChatId}, 1)";
                }
                command.ExecuteNonQuery();
            }
        }
        ///////////////////////////////////////
        ///Buy Stocks
        //////////////////////////////////////
        
        public bool CheckMoney(long ChatId, string countS, string CompanieId)
        {
            int count = Convert.ToInt32(countS);
            int comId = Convert.ToInt32(CompanieId);
            if(count > 2147483640 || count<0)
            {
                return false;
            }
            string sqlExpression = $"select money-({count}*(select currentprice from CompaniesStock where id = {comId})) from Persons where chatid = {ChatId}";
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(0) != DBNull.Value)
                        {
                            int res = Convert.ToInt32(reader.GetValue(0));
                            if (res < 0)
                            {
                                return false;
                            }
                            else
                            {
                                return true;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    return false;
                }
            }
        }

        public void BuyStocks(string CompanieId, long chatId, string countS)
        {
            int comId = Convert.ToInt32(CompanieId);
            long chId = Convert.ToInt64(chatId);
            int count = Convert.ToInt32(countS);
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();

                bool check = CheckMoney(chId, countS, CompanieId);
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                SqliteCommand comm2 = new SqliteCommand();
                comm2.Connection = connection;
                if (check)
                {
                    if (comId == 1)
                    {
                        command.CommandText = $"update Persons set MacrosoftStock = MacrosoftStock + {count} where chatid = {chId}";
                    }
                    else if (comId == 2)
                    {
                        command.CommandText = $"update Persons set LamazonStock = LamazonStock + {count} where chatid = {chId}";
                    }
                    else if (comId == 3)
                    {
                        command.CommandText = $"update Persons set GoogolStock = GoogolStock + {count} where chatid = {chId}";
                    }
                    else if (comId == 4)
                    {
                        command.CommandText = $"update Persons set PersonBookStock = PersonBookStock + {count} where chatid = {chId}";
                    }

                    comm2.CommandText = $"update Persons set money = money - ({count} * (select currentprice from CompaniesStock where id = {comId})) where chatid = {chId}";
                }
                command.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
            }
        }

        /////////////////////////////////
        ///Sell Stocks
        ////////////////////////////////

        public bool CheckStocks(int CompanieId, long chatId, int countS)
        {
            if (countS > 2147483640 || countS < 0)
            {
                return false;
            }
            if (CompanieId == 1)
            {
                string sqlExpression = $"select MacrosoftStock from Persons where chatid = {chatId}";
                using (var connection = new SqliteConnection("Data Source=fgDB.db"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0) != DBNull.Value)
                            {
                                int res = Convert.ToInt32(reader.GetValue(0));
                                if (res - countS < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
            else if (CompanieId == 2)
            {
                string sqlExpression = $"select LamazonStock from Persons where chatid = {chatId}";
                using (var connection = new SqliteConnection("Data Source=fgDB.db"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0) != DBNull.Value)
                            {
                                int res = Convert.ToInt32(reader.GetValue(0));
                                if (res - countS < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
            else if (CompanieId == 3)
            {
                string sqlExpression = $"select GoogolStock from Persons where chatid = {chatId}";
                using (var connection = new SqliteConnection("Data Source=fgDB.db"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0) != DBNull.Value)
                            {
                                int res = Convert.ToInt32(reader.GetValue(0));
                                if (res - countS < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
            else if (CompanieId == 4)
            {
                string sqlExpression = $"select PersonBookStock from Persons where chatid = {chatId}";
                using (var connection = new SqliteConnection("Data Source=fgDB.db"))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand(sqlExpression, connection);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0) != DBNull.Value)
                            {
                                int res = Convert.ToInt32(reader.GetValue(0));
                                if (res - countS < 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        public void SellStocks(string CompanieId, long chatId, string countS)
        {
            int count = Convert.ToInt32(countS);
            int compId = Convert.ToInt32(CompanieId);
            using (var connection = new SqliteConnection("Data Source=fgDB.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                SqliteCommand comm2 = new SqliteCommand();
                comm2.Connection = connection;
                bool check = CheckStocks(compId, chatId, count);
                if (check)
                {
                    if (compId == 1)
                    {
                        command.CommandText = $"update Persons set MacrosoftStock = MacrosoftStock - {count} where chatid = {chatId}";
                    }
                    else if (compId == 2)
                    {
                        command.CommandText = $"update Persons set LamazonStock = LamazonStock - {count} where chatid = {chatId}";
                    }
                    else if (compId == 3)
                    {
                        command.CommandText = $"update Persons set GoogolStock = GoogolStock - {count} where chatid = {chatId}";
                    }
                    else if (compId == 4)
                    {
                        command.CommandText = $"update Persons set PersonBookStock = PersonBookStock - {count} where chatid = {chatId}";
                    }

                    comm2.CommandText = $"update Persons set money = money + ({count} * (select currentprice from CompaniesStock where id = {compId})) where chatid = {chatId}";
                }
                command.ExecuteNonQuery();
                comm2.ExecuteNonQuery();
            }
        }

        //////////////////////////////
        ///Rounds
        /////////////////////////////

        public void NewRound()
        {
            ChangePrices("1");
            ChangePrices("2");
            ChangePrices("3");
            ChangePrices("4");
            ChangeChangerCompPrice();
        }

    }
}
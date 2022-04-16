using System;
using System.Threading;
using Microsoft.Data.Sqlite;

namespace FinanceGameBot
{
    class FinGameDB
    {
        //////////////////
        ///Get Persons Info
        /////////////////

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

        public int AlgForPrice( string CompanieId)
        {
            int cId = Convert.ToInt32(CompanieId);
            int cprice = GetCurrentPrice(CompanieId);
            if(cprice <= 10)
            {
                cprice += 5;
                return cprice;
            }
            if(cprice >=2500)
            {
                cprice -= 200;
                return cprice;
            }
            Random rnd = new Random();
            int value = rnd.Next(700, 1300);
            float changer = (Convert.ToSingle(value)) / 1000;
            int res = Convert.ToInt32((Convert.ToSingle(cprice)) * changer);
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
        }

    }
}


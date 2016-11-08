using CompropagoSdk.Factory.Abs;
using CompropagoSdk.Models;
using CompropagoSdk.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CompropagoSdk.Test
{
    [TestClass]
    public class UnitTest
    {
        private string publickey  = "pk_test_638e8b14112423a086";
        private string privatekey = "sk_test_9c95e149614142822f";
        private bool mode = false;

        private string phone_number = "5561463627";

        [TestMethod]
        public void TestCreateClient()
        {
            bool res = false;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                res = !client.Equals(null);
            }
            catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestEvalAuth()
        {
            bool res = false;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                EvalAuthInfo response = Validations.evalAuth(client);

                res = !response.Equals(null);
            }catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceProviders()
        {
            bool res = false;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                var response = client.api.listProviders();

                res = (response.Count > 0);
            }catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceProvidersLimit()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                List<Provider> response = client.api.listProviders(false,15000);

                foreach (Provider provider in response)
                {
                    if (provider.transaction_limit < 15000)
                    {
                        res = false;
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceProvidersAuth()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                List<Provider> response = client.api.listProviders(true);

                res = (response.Count > 0);
            }catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceProvidersAuthLimit()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                List<Provider> response = client.api.listProviders(true, 15000);

                if(response.Count > 0)
                {
                    foreach (Provider provider in response)
                    {
                        if (provider.transaction_limit < 15000)
                        {
                            res = false;
                            break;
                        }
                    }
                }
                else
                {
                    res = false;
                }
            }catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceProvidersAuthFetch()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                List<Provider> response = client.api.listProviders(true, 15000, true);

                if(response.Count > 0)
                {
                    foreach(Provider provider in response)
                    {
                        if(provider.transaction_limit < 15000)
                        {
                            res = false;
                            break;
                        }
                    }
                }else
                {
                    res = false;
                }
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderDefault()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com"    
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderOxxo()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "OXXO"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrder7Eleven()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "SEVEN_ELEVEN"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderCoppel()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "COPPEL"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderExtra()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "EXTRA"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderFarmaciaEsquivar()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "FARMACIA_ESQUIVAR"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderElektra()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "ELEKTRA"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderCasaLey()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "CASA_LEY"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderPitico()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "PITICO"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderTelecomm()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "TELECOMM"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServicePlaceOrderFarmaciaABC()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com",
                    "FARMACIA_ABC"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                res = !neworder.getId().Equals(null);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceVerifyOrder()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                CpOrderInfo response = client.api.verifyOrder(neworder.getId());
                res = !response.getId().Equals(null);
            }
            catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceSms()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                PlaceOrderInfo order = new PlaceOrderInfo(
                    "12",
                    "M4 C# SDK",
                    180,
                    "Eduardo Aguilar",
                    "eduardo.aguilar@compropago.com"
                );
                NewOrderInfo neworder = client.api.placeOrder(order);
                SmsInfo response = client.api.sendSmsInstructions(phone_number, neworder.getId());
                res = !response.getType().Equals("");
            }
            catch(Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceListWebhooks()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                List<Webhook> response = client.api.listWebhooks();

                res = (response.Count > 0);
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceCreateWebhook()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                Webhook response = client.api.createWebhook("http://prueba.com");

                res = response.status.Equals("new") || response.status.Equals("exist");
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceUpdateWebhook()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                Webhook response = client.api.createWebhook("http://prueba.com");
                response = client.api.updateWebhook(response.id, "prueba2.com");

                res = response.status.Equals("updated");
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestServiceDeleteWebhook()
        {
            bool res = true;
            try
            {
                Client client = new Client(publickey, privatekey, mode);
                Webhook response = client.api.createWebhook("prueba2.com");
                response = client.api.deleteWebhook(response.id);

                res = response.status.Equals("deleted");
            }
            catch (Exception e)
            {
                res = false;
            }

            Assert.IsTrue(res);
        }
    }
}

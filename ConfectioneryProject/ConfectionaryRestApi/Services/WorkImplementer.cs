﻿using ConfectioneryShopModelServiceDAL.BindingModel;
using ConfectioneryShopModelServiceDAL.LogicInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ConfectionaryRestApi.Services
{
    public class WorkImplementer
    {
        private readonly IMainService _service;

        private readonly IImplementerService _serviceImplementer;
        private readonly int _implementerId;

        private readonly int _orderId;
        // семафор
        static Semaphore _sem = new Semaphore(3, 3);

        Thread myThread;

        public WorkImplementer(IMainService service, IImplementerService serviceImplementer, int implementerId, int orderId)
        {
            _service = service;
            _serviceImplementer = serviceImplementer;
            _implementerId = implementerId;
            _orderId = orderId;

            try
            {
                _service.takeOrderInWork(new OrderBindingModel
                {
                    ID = _orderId,
                    ImplementerId = _implementerId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            myThread = new Thread(Work);
            myThread.Start();
        }

        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(10000);
                _service.finishOrder(new OrderBindingModel
                {
                    ID = _orderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}
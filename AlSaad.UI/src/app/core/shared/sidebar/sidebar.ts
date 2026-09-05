import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { Category } from '../../models/Category';

@Component({
  selector: 'app-sidebar',
  standalone:true,
  imports: [CommonModule, RouterModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})
export class Sidebar {
   categories: Category[] = [
    {
      label: 'كشف الأسعار',
      path: "",
      children: [
        { label: 'انواع السيارات  ', path: '/makers' },
        { label: 'الماركات', path: '/prices/oils' },
        { label: ' التصنيفات', path: '/prices/filters' }
      ]
    },

    {
      label: 'بحث بالكود أو رقم القطعة',
            path: "",

      children: [
        { label: 'بحث بالكود', path: '/search/code' },
        { label: 'بحث برقم القطعة', path: '/search/part-number' }
      ]
    },

    {
      label: 'عروض خاصة',
            path: "",

      children: [
        { label: 'عروض اليوم', path: '/offers/today' },
        { label: 'العروض الجديدة', path: '/offers/new' }
      ]
    },

    {
      label: 'حسابك',
            path: '/account',
    },

    {
      label: 'طلباتك القديمة',
            path: "",

      children: [
        { label: 'كل الطلبات', path: '/orders' },
        { label: 'الطلبات المكتملة', path: '/orders/completed' },
        { label: 'الطلبات الملغاة', path: '/orders/cancelled' }
      ]
    },
  {
    label: 'المنتجات',
    path: '/products',
  },
    {
      label: 'سلة طلباتك',
      path: '/carts'
    }

  ];
}

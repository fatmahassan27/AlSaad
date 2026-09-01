import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CartItem } from '../../models/Cart-Item';


@Component({
  selector: 'app-cart',
  standalone:true,
  imports: [CommonModule, RouterModule],
  templateUrl: './cart.html',
  styleUrl: './cart.css',
})
export class Cart {
   items: CartItem[] = [
    {
      code: 'SP-001',
      name: 'فلتر زيت',
      model: 'Corolla 2024',
      brand: 'Toyota',
      origin: 'Japan',
      notes: 'قطعة أصلية',
      price: 850,
      qty: 2
    },
    {
      code: 'SP-002',
      name: 'تيل فرامل أمامي',
      model: 'Elantra 2023',
      brand: 'Hyundai',
      origin: 'Korea',
      notes: 'جودة عالية',
      price: 1200,
      qty: 1
    },
    {
      code: 'SP-003',
      name: 'فلتر هواء',
      model: 'Sportage 2024',
      brand: 'Kia',
      origin: 'Korea',
      notes: 'مناسب للموديل',
      price: 650,
      qty: 3
    }
  ];

  remove(code: string): void {
    this.items = this.items.filter(item => item.code !== code);
  }

  get totalPrice(): number {
    return this.items.reduce(
      (total, item) => total + (item.price * item.qty),
      0
    );
  }
}

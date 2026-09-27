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
    discount = 0;

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

  getsubtotal(): number {
    return this.items.reduce(
      (sum, item) => sum + item.price * item.qty,
      0
    );
  }
  remove(code: string): void {
    this.items = this.items.filter(item => item.code !== code);
  }

increaseQty(item: CartItem): void {
    item.qty += 1;
  }
 
  decreaseQty(item: CartItem): void {
    if (item.qty > 1) {
      item.qty -= 1;
    }
  }
 
  removeItem(item: CartItem): void {
    this.items = this.items.filter((i) => i !== item);
  }
 
  submitOrder(): void {
    if (!this.items.length) {
      return;
    }
    console.log('Order submitted:', this.items);
  }
  
}

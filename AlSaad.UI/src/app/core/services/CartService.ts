import { Injectable, signal } from '@angular/core';
import { CartItem } from '../models/Cart-Item';
@Injectable(
  { providedIn: 'root' }
)
export class CartService {
  private itemsSignal = signal<CartItem[]>([]);
  items = this.itemsSignal.asReadonly();

  addItem(item: CartItem): void {
    const existing = this.itemsSignal().find(i => i.code === item.code);
    if (existing) {
      this.itemsSignal.update(items =>
        items.map(i => (i.code === item.code ? { ...i, qty: i.qty + item.qty } : i))
      );
    } else {
      this.itemsSignal.update(items => [...items, item]);
    }
  }

  removeItem(code: string): void {
    this.itemsSignal.update(items => items.filter(i => i.code !== code));
  }

  clear(): void {
    this.itemsSignal.set([]);
  }

  get totalCount(): number {
    return this.itemsSignal().length;
  }

  get totalPrice(): number {
    return this.itemsSignal().reduce((sum, i) => sum + i.price * i.qty, 0);
  }
}
import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import {  Cart } from '../../features/cart/cart';
import { Parts } from '../../models/Parts';
import { ModelOption } from '../../models/ModelOption';
import { CartItem } from '../../models/Cart-Item';
import { CartService } from '../../services/CartService';

@Component({
  selector: 'app-part',
  imports: [CommonModule, FormsModule, RouterModule],  
  templateUrl: './part.html',
  styleUrl: './part.css',
})
export class Part implements OnInit{
   makerId = 0;
  makerName = '';
  modelId = 0;
  modelName = '';
  searchTerm = '';
  //searched items 
  codeSearch = '';
nameSearch = '';
brandSearch = '';
originSearch = '';
notesSearch = '';
priceSearch = '';
   allModels: ModelOption[] = [
    { id: 101, makerId: 1, name: 'سيراتو', yearsRange: '2014-2018' },
    { id: 102, makerId: 1, name: 'سبورتاج', yearsRange: '2016-2021' },
    { id: 103, makerId: 1, name: 'ريو', yearsRange: '2012-2017' },
    { id: 104, makerId: 1, name: 'بيكانتو', yearsRange: '2015-2020' },
    { id: 201, makerId: 2, name: 'i10', yearsRange: '2012-2018' },
    { id: 202, makerId: 2, name: 'i10', yearsRange: '2008-2010' },
    { id: 203, makerId: 2, name: 'HY كوبيه', yearsRange: '2005-2010' },
    { id: 204, makerId: 2, name: 'IX35', yearsRange: '2013-2016' },
    { id: 205, makerId: 2, name: 'i30', yearsRange: '2010' },
    { id: 206, makerId: 2, name: 'i20', yearsRange: '2021 (1400)' },
    { id: 207, makerId: 2, name: 'كريتا', yearsRange: '2019' },
    { id: 208, makerId: 2, name: 'كريتا', yearsRange: '2016' },
    { id: 209, makerId: 2, name: 'أكسنت HCI', yearsRange: '2021 (1400)' },
    { id: 210, makerId: 2, name: 'جراند i10', yearsRange: '2016' },
    { id: 211, makerId: 2, name: 'H-1', yearsRange: '2007-2014' },
    { id: 212, makerId: 2, name: 'كريتا', yearsRange: '2021' },
    { id: 301, makerId: 3, name: 'أفيو', yearsRange: '2011-2016' },
    { id: 302, makerId: 3, name: 'لانوس', yearsRange: '2002-2008' },
    { id: 303, makerId: 3, name: 'أوبترا', yearsRange: '2007-2012' },
    { id: 401, makerId: 4, name: 'كورندو', yearsRange: '2011-2015' },
    { id: 402, makerId: 4, name: 'أكتيون', yearsRange: '2010-2014' }
  ];

  modelsForMaker: ModelOption[] = [];

  allParts: Parts[] = [
    { code: 'KR43948GK', name: 'طقم بلي عجل أمامي', brand: 'أصلي', origin: 'كوريا', notes: 'يمين/شمال', price: 450 },
    { code: 'KR43961GK', name: 'دسك فرامل أمامي', brand: 'أصلي', origin: 'كوريا', notes: '-', price: 620 },
    { code: 'KR43947GK', name: 'فحمات فرامل خلفي', brand: 'بديل ممتاز', origin: 'الصين', notes: '-', price: 280 },
    { code: 'KR51022FL', name: 'فلتر زيت', brand: 'أصلي', origin: 'كوريا', notes: '-', price: 95 },
    { code: 'KR51045FA', name: 'فلتر هواء', brand: 'بديل ممتاز', origin: 'تايوان', notes: '-', price: 120 },
    { code: 'KR60011SP', name: 'طقم بوجيهات إشعال', brand: 'أصلي', origin: 'اليابان', notes: '4 حبات', price: 340 },
    { code: 'KR71034AC', name: 'كمبروسر تكييف', brand: 'أصلي', origin: 'كوريا', notes: '-', price: 3200 },
    { code: 'KR81002RD', name: 'رديتر مياه', brand: 'بديل ممتاز', origin: 'الصين', notes: '-', price: 950 },
    { code: 'KR91056SH', name: 'طقم مساعدين أمامي', brand: 'أصلي', origin: 'كوريا', notes: 'يمين وشمال', price: 1850 },
    { code: 'KR91078SH', name: 'طقم مساعدين خلفي', brand: 'بديل ممتاز', origin: 'الصين', notes: 'يمين وشمال', price: 1400 }
  ];

    quantities: { [code: string]: number } = {};
 constructor(private route: ActivatedRoute, public router: Router,public cart: CartService ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.makerId = Number(params['makerId']) || 0;
      this.makerName = params['makerName'] || '';
      this.modelId = Number(params['modelId']) || 0;
      this.modelName = params['modelName'] || '';
      this.modelsForMaker = this.allModels.filter(m => m.makerId === this.makerId);
    });

    this.allParts.forEach(p => (this.quantities[p.code] = 1));
  }

  // get filteredParts(): Parts[] {
  //   if (!this.searchTerm.trim()) return this.allParts;
  //   const term = this.searchTerm.trim().toLowerCase();
  //   return this.allParts.filter(
  //     p => p.name.toLowerCase().includes(term) || p.code.toLowerCase().includes(term)
  //   );
  // }
get filteredParts(): Parts[] {

  const code = this.codeSearch.trim().toLowerCase();
  const name = this.nameSearch.trim().toLowerCase();
  const brand = this.brandSearch.trim().toLowerCase();
  const origin = this.originSearch.trim().toLowerCase();
  const notes = this.notesSearch.trim().toLowerCase();
  const price = this.priceSearch.trim().toLowerCase();

  return this.allParts.filter(part => {

    const matchesCode =
      !code ||
      part.code.toLowerCase().includes(code);

    const matchesName =
      !name ||
      part.name.toLowerCase().includes(name);

    const matchesBrand =
      !brand ||
      part.brand.toLowerCase().includes(brand);

    const matchesOrigin =
      !origin ||
      part.origin.toLowerCase().includes(origin);

    const matchesNotes =
      !notes ||
      part.notes.toLowerCase().includes(notes);

    const matchesPrice =
      !price ||
      part.price.toString().includes(price);

    return (
      matchesCode &&
      matchesName &&
      matchesBrand &&
      matchesOrigin &&
      matchesNotes &&
      matchesPrice
    );
  });
}
  getTotal(part: Parts): number {
    return part.price * (this.quantities[part.code] || 1);
  }

  addToCart(part: Parts): void {
    const qty = this.quantities[part.code] || 1;
    const item: CartItem = {
      code: part.code,
      name: part.name,
      model: this.modelName,
      brand: part.brand,
      origin: part.origin,
      notes: part.notes,
      price: part.price,
      qty
    };
    this.cart.addItem(item);
  }

  onModelSwitch(): void {
    const model = this.modelsForMaker.find(m => m.id === Number(this.modelId));
    if (!model) return;
    this.modelName = model.name + ' ' + model.yearsRange;
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: { modelId: model.id, modelName: this.modelName },
      queryParamsHandling: 'merge'
    });
  }

  clearFilters(): void {
  this.codeSearch = '';
  this.nameSearch = '';
  this.brandSearch = '';
  this.originSearch = '';
  this.notesSearch = '';
  this.priceSearch = '';
}
}

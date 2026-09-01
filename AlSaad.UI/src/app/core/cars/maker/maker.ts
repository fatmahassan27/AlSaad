import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { Makers } from '../../models/Makers';

@Component({
  selector: 'app-maker',
  imports: [CommonModule],
  templateUrl: './maker.html',
  styleUrl: './maker.css',
})
export class Maker {
   makers: Makers[] = [
    { id: 1, name: 'كيا', englishName: 'KIA', colorClass: 'brand-kia' },
    { id: 2, name: 'هيونداي', englishName: 'HYUNDAI', colorClass: 'brand-hyundai' },
    { id: 3, name: 'شيفروليه - دايو', englishName: 'CHEVROLET / DAEWOO', colorClass: 'brand-chevrolet' },
    { id: 4, name: 'سيان يونج', englishName: 'SSANGYONG', colorClass: 'brand-ssangyong' }
  ];

  constructor(private router: Router) {}

  goToModels(maker: Makers): void {
    this.router.navigate(['/models'], { queryParams: { makerId: maker.id, makerName: maker.name } });
  }
}

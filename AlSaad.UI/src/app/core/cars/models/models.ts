import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { CarModel } from '../../models/CarModel';
@Component({
  selector: 'app-models',
  imports: [CommonModule],
  templateUrl: './models.html',
  styleUrl: './models.css',
})
export class Models implements OnInit {

    makerId!: number;
    makerName = '';
    allModels: CarModel[] = [
    // كيا (makerId = 1)
    { id: 101, makerId: 1, name: 'سيراتو', yearsRange: '2014-2018' },
    { id: 102, makerId: 1, name: 'سبورتاج', yearsRange: '2016-2021' },
    { id: 103, makerId: 1, name: 'ريو', yearsRange: '2012-2017' },
    { id: 104, makerId: 1, name: 'بيكانتو', yearsRange: '2015-2020' },

    // هيونداي (makerId = 2)
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

    // شيفروليه / دايو (makerId = 3)
    { id: 301, makerId: 3, name: 'أفيو', yearsRange: '2011-2016' },
    { id: 302, makerId: 3, name: 'لانوس', yearsRange: '2002-2008' },
    { id: 303, makerId: 3, name: 'أوبترا', yearsRange: '2007-2012' },

    // سيان يونج (makerId = 4)
    { id: 401, makerId: 4, name: 'كورندو', yearsRange: '2011-2015' },
    { id: 402, makerId: 4, name: 'أكتيون', yearsRange: '2010-2014' }
  ];

  filteredModels: CarModel[] = [];

  constructor(private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.makerId = Number(params['makerId']) || 0;
      this.makerName = params['makerName'] || '';
      this.filteredModels = this.allModels.filter(m => m.makerId === this.makerId);
    });
  }

  goToParts(model: CarModel): void {
    this.router.navigate(['/parts'], {
      queryParams: {
        makerId: this.makerId,
        makerName: this.makerName,
        modelId: model.id,
        modelName: model.name + ' ' + model.yearsRange
      }
    });
  }

  goBackToMakers(): void {
    this.router.navigate(['/makers']);
  }
}

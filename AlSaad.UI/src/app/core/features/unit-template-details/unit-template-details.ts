import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { UnitTemplateService } from '../../services/unit-template-service';
import { UnitTemplate } from '../../models/UnitFactor';

@Component({
  selector: 'app-unit-template-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './unit-template-details.html',
  styleUrl: './unit-template-details.css',
})
export class UnitTemplateDetails implements OnInit {
  template: UnitTemplate | null = null;
  isLoading = true;
  errorMessage = '';

  constructor(
    private route: ActivatedRoute,
    private unitTemplateService: UnitTemplateService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم القالب غير صحيح.';
      this.isLoading = false;
      return;
    }

    this.unitTemplateService.getUnitTemplateById(id).subscribe({
      next: (data) => {
        this.template = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading unit template', err);
        this.errorMessage = 'القالب ده مش موجود أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}
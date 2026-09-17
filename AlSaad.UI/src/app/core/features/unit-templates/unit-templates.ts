import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UnitTemplateService } from '../../services/unit-template-service';
import { UnitTemplate } from '../../models/UnitFactor';

@Component({
  selector: 'app-unit-templates',
  imports: [CommonModule, RouterModule],
  templateUrl: './unit-templates.html',
  styleUrl: './unit-templates.css',
})
export class UnitTemplates implements OnInit {
  templates: UnitTemplate[] = [];
  isLoading = true;
  errorMessage = '';

  constructor(private unitTemplateService: UnitTemplateService) {}

  ngOnInit(): void {
    this.loadTemplates();
  }

  loadTemplates(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.unitTemplateService.getUnitTemplates().subscribe({
      next: (result) => {
        this.templates = result.items;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading unit templates', err);
        this.errorMessage = 'حصل خطأ في تحميل قوالب الوحدات، حاول تاني.';
        this.isLoading = false;
      },
    });
  }
}
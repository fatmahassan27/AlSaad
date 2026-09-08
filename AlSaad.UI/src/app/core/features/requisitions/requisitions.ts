import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RequisitionService } from '../../services/requisition-service';
import { Requisition, getRequisitionTypeLabel, getRequisitionStatusLabel } from '../../models/RequisitionItem';
@Component({
  selector: 'app-requisitions',
  imports: [CommonModule,RouterModule],
  templateUrl: './requisitions.html',
  styleUrl: './requisitions.css',
})
export class Requisitions implements OnInit {

   requisitions: Requisition[] = [];
  isLoading = true;
  errorMessage = '';

    // نخليهم متاحين في الـ templates
  getTypeLabel = getRequisitionTypeLabel;
  getStatusLabel = getRequisitionStatusLabel;
  constructor(private requisitionService: RequisitionService) {}

  ngOnInit(): void {
    this.loadRequisitions();
  }


  loadRequisitions(): void {
    this.isLoading = true;
    this.errorMessage = '';

    this.requisitionService.getRequisitions().subscribe({
      next: (result) => {
        this.requisitions = result.items;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading requisitions', err);
        this.errorMessage = 'حصل خطأ في تحميل حركات المخزون، حاول تاني.';
        this.isLoading = false;
      },
    });
  }
}

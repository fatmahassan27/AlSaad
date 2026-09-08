import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { RequisitionService } from '../../services/requisition-service';
import { Requisition, getRequisitionTypeLabel, getRequisitionStatusLabel } from '../../models/RequisitionItem';

@Component({
  selector: 'app-requisition-details',
  imports: [CommonModule, RouterModule],
  templateUrl: './requisition-details.html',
  styleUrl: './requisition-details.css',
})
export class RequisitionDetails implements OnInit {

    requisition: Requisition | null = null;
  isLoading = true;
  errorMessage = '';

  getTypeLabel = getRequisitionTypeLabel;
  getStatusLabel = getRequisitionStatusLabel;

  constructor(
    private route: ActivatedRoute,
    private requisitionService: RequisitionService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMessage = 'رقم الحركة غير صحيح.';
      this.isLoading = false;
      return;
    }

    this.requisitionService.getRequisitionById(id).subscribe({
      next: (data) => {
        this.requisition = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error loading requisition', err);
        this.errorMessage = 'الحركة دي مش موجودة أو حصل خطأ في التحميل.';
        this.isLoading = false;
      },
    });
  }
}

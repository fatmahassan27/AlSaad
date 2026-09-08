import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StockTransactionDetails } from './stock-transaction-details';

describe('StockTransactionDetails', () => {
  let component: StockTransactionDetails;
  let fixture: ComponentFixture<StockTransactionDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StockTransactionDetails],
    }).compileComponents();

    fixture = TestBed.createComponent(StockTransactionDetails);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

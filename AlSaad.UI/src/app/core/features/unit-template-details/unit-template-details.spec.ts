import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitTemplateDetails } from './unit-template-details';

describe('UnitTemplateDetails', () => {
  let component: UnitTemplateDetails;
  let fixture: ComponentFixture<UnitTemplateDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UnitTemplateDetails],
    }).compileComponents();

    fixture = TestBed.createComponent(UnitTemplateDetails);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

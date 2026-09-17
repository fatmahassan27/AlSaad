import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnitTemplates } from './unit-templates';

describe('UnitTemplates', () => {
  let component: UnitTemplates;
  let fixture: ComponentFixture<UnitTemplates>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UnitTemplates],
    }).compileComponents();

    fixture = TestBed.createComponent(UnitTemplates);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

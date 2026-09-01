import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Maker } from './maker';

describe('Maker', () => {
  let component: Maker;
  let fixture: ComponentFixture<Maker>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Maker],
    }).compileComponents();

    fixture = TestBed.createComponent(Maker);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

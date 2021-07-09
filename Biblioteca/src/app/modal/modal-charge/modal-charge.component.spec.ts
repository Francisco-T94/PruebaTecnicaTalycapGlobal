import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalChargeComponent } from './modal-charge.component';

describe('ModalChargeComponent', () => {
  let component: ModalChargeComponent;
  let fixture: ComponentFixture<ModalChargeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalChargeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalChargeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

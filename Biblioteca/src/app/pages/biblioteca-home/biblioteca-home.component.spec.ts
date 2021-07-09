import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BibliotecaHomeComponent } from './biblioteca-home.component';

describe('BibliotecaHomeComponent', () => {
  let component: BibliotecaHomeComponent;
  let fixture: ComponentFixture<BibliotecaHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BibliotecaHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BibliotecaHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

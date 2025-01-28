import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLoginsComponent } from './add-logins.component';

describe('AddLoginsComponent', () => {
  let component: AddLoginsComponent;
  let fixture: ComponentFixture<AddLoginsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddLoginsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddLoginsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

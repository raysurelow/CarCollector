import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GarageSelectorComponent } from './garage-selector.component';

describe('GarageSelectorComponent', () => {
  let component: GarageSelectorComponent;
  let fixture: ComponentFixture<GarageSelectorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GarageSelectorComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GarageSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

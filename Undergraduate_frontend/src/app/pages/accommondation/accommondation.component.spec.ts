import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccommondationComponent } from './accommondation.component';

describe('AccommondationComponent', () => {
  let component: AccommondationComponent;
  let fixture: ComponentFixture<AccommondationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AccommondationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AccommondationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

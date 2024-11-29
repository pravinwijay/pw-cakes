import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasserCommandeComponent } from './passer-commande.component';

describe('PasserCommandeComponent', () => {
  let component: PasserCommandeComponent;
  let fixture: ComponentFixture<PasserCommandeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PasserCommandeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PasserCommandeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

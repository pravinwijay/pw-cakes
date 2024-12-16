import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PasserCommandeComponent } from './partie_client/passer-commande/passer-commande.component';
import { AccueilClientComponent } from './partie_client/accueil-client/accueil-client.component';
import { VoirCatalogueComponent } from './partie_client/voir-catalogue/voir-catalogue.component';

const routes: Routes = [
  {path: '', component: AccueilClientComponent},
  {path: 'passer-commande', component: PasserCommandeComponent},
  {path: 'visiter-catalogue', component: VoirCatalogueComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

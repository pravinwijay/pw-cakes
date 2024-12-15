import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InscriptionComponent } from './inscription/inscription.component';
import { ConnexionComponent } from './connexion/connexion.component';
import { AccueilClientComponent } from './partie_client/accueil-client/accueil-client.component';
import { AccueilAdminComponent } from './partie_admin/accueil-admin/accueil-admin.component';
import { PasserCommandeComponent } from './partie_client/passer-commande/passer-commande.component';
import { ListeCommandesComponent } from './partie_admin/liste-commandes/liste-commandes.component';
import { ModifCommandeComponent } from './partie_admin/modif-commande/modif-commande.component';
import { AjoutCatalogueComponent } from './partie_admin/ajout-catalogue/ajout-catalogue.component';
import { StyleClassModule } from 'primeng/styleclass';
import { ChipsModule } from 'primeng/chips';
import { ChipModule } from 'primeng/chip';
import { ButtonModule } from 'primeng/button';
import { RippleModule } from 'primeng/ripple';


@NgModule({
  declarations: [
    AppComponent,
    InscriptionComponent,
    ConnexionComponent,
    AccueilClientComponent,
    AccueilAdminComponent,
    PasserCommandeComponent,
    ListeCommandesComponent,
    ModifCommandeComponent,
    AjoutCatalogueComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    ChipsModule,
    StyleClassModule,
    ChipModule,
    ButtonModule,
    RippleModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

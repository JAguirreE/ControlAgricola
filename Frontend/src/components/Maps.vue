<template>
  <section id="maps">
    <mdb-row>
      <mdb-col md="3">
        <mdb-card>
          <mdb-view hover>
            <router-link :to="{ name: 'Finca'}">
              <mdb-card-image
                src="https://cdn.pixabay.com/photo/2015/03/21/16/31/farm-683866_1280.jpg"
                alt="Card image cap"/>
              <mdb-mask flex-center waves overlay="white-slight"></mdb-mask>
            </router-link>
          </mdb-view>
          <mdb-card-body>
            <mdb-card-title>Registro de Fincas</mdb-card-title>
          </mdb-card-body>
        </mdb-card>
      </mdb-col>
      <mdb-col md="3">
        <mdb-card>
          <mdb-view hover>
            <router-link :to="{ name: 'Lote'}">
              <mdb-card-image
                src="https://images.pexels.com/photos/1228574/pexels-photo-1228574.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                alt="Card image cap"/>
              <mdb-mask flex-center waves overlay="white-slight"></mdb-mask>
            </router-link>
          </mdb-view>
          <mdb-card-body>
            <mdb-card-title>Registro de Lotes</mdb-card-title>
          </mdb-card-body>
        </mdb-card>
      </mdb-col>
      <mdb-col md="3">
        <mdb-card>
          <mdb-view hover>
            <router-link :to="{ name: 'Usuario'}">
              <mdb-card-image
                src="https://images.pexels.com/photos/2515879/pexels-photo-2515879.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                alt="Card image cap"/>
              <mdb-mask flex-center waves overlay="white-slight"></mdb-mask>
            </router-link>
          </mdb-view>
          <mdb-card-body>
            <mdb-card-title>Registro de Usuarios</mdb-card-title>
          </mdb-card-body>
        </mdb-card>
      </mdb-col>
    </mdb-row>
  </section>
</template>

<script>
import { mdbRow, mdbCol, mdbCard, mdbCardImage, mdbCardBody, mdbCardTitle, mdbCardText, mdbBtn, mdbView, mdbMask } from 'mdbvue'

export default {
  name: 'Maps',
  components: {
    mdbRow,
    mdbCol,
    mdbCard,
    mdbView,
    mdbCardImage,
    mdbCardBody,
    mdbCardTitle,
    mdbCardText,
    mdbBtn,
    mdbMask
  },
  data () {
    return {
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.card.card-cascade .view.gradient-card-header {
  padding: 1rem 1rem;
  text-align: center;
}
.card.card-cascade h3, .card.card-cascade h4 {
  margin-bottom: 0px;
}
</style>

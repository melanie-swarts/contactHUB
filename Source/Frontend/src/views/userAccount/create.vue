<template>
  <div>
    <div class="box-info">
          <div class="header-container">
      <div class="header-text">Create Account</div>
    </div>
      <div class="box-form">
                <el-row>
                  <el-form>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="systemUser.FirstName"
                      :rules="personalDetailRules.FirstName"
                      label="First Name"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="systemUser.LastName"
                      :rules="personalDetailRules.LastName"
                      label="Last Name"
                      required
                    />
                  </el-col>
                </el-row>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="systemUser.PrimaryContactNumber"
                      :rules="personalDetailRules.PrimaryContactNumber"
                      label="Primary Contact Number"
                      type="number"
                      :counter="10"
                      :maxlength="10"
                      required
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="systemUser.MobileNumber"
                      label="Mobile Number"
                      type="number"
                      :counter="10"
                      :maxlength="10"
                    />
                  </el-col>
                </el-row>
                <el-row>
                  <el-col :span="11">
                    <v-text-field
                      v-model="systemUser.HomeNumber"
                      label="Home Number"
                      type="number"
                      :counter="10"
                      :maxlength="10"
                    />
                  </el-col>
                  <el-col :span="1">
                    <br>
                  </el-col>
                  <el-col :span="12">
                    <v-text-field
                      v-model="systemUser.WorkNumber"
                      label="Work Number"
                      type="number"
                      :counter="10"
                      :maxlength="10"
                    />
                  </el-col>
                </el-row>
                <br />
                                <br />
      <el-button
        :loading="loading"
        type="primary"
        class="btn btn-primary btn-raised btn-lg"
        style="width:100%;margin-bottom:30px;"
        @click.native.prevent="handleCreate">Submit</el-button>
                  </el-form>
                </el-row>
      </div>
    </div>
  </div>
</template>

<script>
import { mapState } from 'vuex'
import moment from 'moment'

export default {
  name: 'CreateAccount',
  data() {
    return {
      systemUser: this.createSystemUserObject(),
      loading: false,
      personalDetailRules: {
        FirstName: [val => (val || '').length > 0 || 'First Name is required.'],
        LastName: [val => (val || '').length > 0 || 'Last Name is required'],
        PrimaryContactNumber: [val => (val || '').length > 0 || 'Primary Contact Number is required.']
      },
    }
  },
  computed: {
       personalDetailformIsValid () {
        return (
          this.systemUser.FirstName &&
          this.systemUser.LastName &&
          this.systemUser.PrimaryContactNumber &&
          this.systemUser.MobileNumber
        )
      },

    ...mapState(['user', 'snackbar'])
  },
  methods: {
    createSystemUserObject() {
      return {
        FirstName: null,
        LastName: null,
        PrimaryContactNumber: null,
        MobileNumber: null,
        HomeNumber: null,
        WorkNumber: null,
        CreatedAt: moment(Date()).format(),
        AspNetUserId: this.$store.getters.identifier
      }
    },
    handleCreate() {
          this.loading = true
          this.$store.dispatch('CreateNewUser', this.systemUser).then(() => {
            this.loading = false
            this.$router.push({ path: this.redirect || '/' })
          }).catch(() => {
            this.loading = false
          })
        }
    }
}
</script>

<style>
.primary{
    color: #fff !important;
    background-color: #3C565B !important;
}

.primary--text{
    color: #3C565B !important;
}

.box-header {
  color: #444;
  display: block;
  /* text-align: center; */
  margin-top: 1.5rem;
  font-size: 22px;
  line-height: 1;
  font-weight: 500;
  box-sizing: border-box;
}

.info-card-row {
  width: 100%;
  align-content: center !important;
}

.info-card-header{
  display: block;
  font-size: 20px;
  line-height: 1;
  font-weight: 500;
  text-transform: uppercase;
  color: grey;
  text-align: center;
  padding-top: 5px;
  padding-bottom: 25px;
}

.section-info-header {
  display: block;
  font-size: 16px;
  line-height: 1;
  font-weight: 500;
  text-transform: uppercase;
  color: darkgrey;
  text-align: center;
  padding-top: 5px;
  padding-bottom: 25px;
}

.info-form-box {
  border: 0.5px solid lightgray;
  padding: 5px 15px 10px 15px;
}

.register-btn{
  width: 150px;
  height: 50px;
}
</style>

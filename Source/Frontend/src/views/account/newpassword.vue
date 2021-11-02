<template>
  <div class="login-container">
    <el-form
      ref="newPasswordForm"
      :model="newPasswordForm"
      :rules="loginRules"
      class="login-form"
      label-position="left"
    >
      <div class="title-container">
        <img class="logo" src="@/assets/images/logo.png" alt="contactHUB">
        <h3 class="title">Reset account password</h3>
      </div>
      <el-form-item prop="username">
        <span class="svg-container">
          <svg-icon icon-class="user"/>
        </span>
        <el-input
          v-model="newPasswordForm.username"
          placeholder="Email"
          name="username"
          type="text"
        />
      </el-form-item>

      <el-button
        :loading="loading"
        type="primary"
        class="btn btn-primary btn-raised btn-lg"
        style="width:100%;margin-bottom:30px;"
        @click.native.prevent="newPasswordRequest">Reset Password</el-button>

        <div class="reset-info">You will receive an email with a link to reset your password. <br> If it doesn't appear within a few minutes, check your spam folder.</div>
    </el-form>
  </div>
</template>

<script>
import { isvalidUsername } from '@/utils/validate'

export default {
  name: 'NewPassword',
  data() {
    const validateUsername = (rule, value, callback) => {
      if (!isvalidUsername(value)) {
        callback(new Error('Please enter the correct user name'))
      } else {
        callback()
      }
    }
    return {
      newPasswordForm: {
        UserName: ''
      },
      loginRules: {
        UserName: [{ required: true, trigger: 'blur', validator: validateUsername }]
      },
      loading: false,
      showDialog: false,
      redirect: undefined
    }
  },
  watch: {
    $route: {
      handler: function(route) {
        this.redirect = route.query && route.query.redirect
      },
      immediate: true
    }

  },
  methods: {
    newPasswordRequest() {
      this.$refs.newPasswordForm.validate(valid => {
        if (valid) {
          this.loading = true
          this.$store.dispatch('ResetUserPassword', this.newPasswordForm).then(() => {
            this.loading = false
            this.$router.push({ path: this.redirect || '/' })
          }).catch(() => {
            this.loading = false
          })
        } else {
          console.log('error submit!!')
          return false
        }
      })
    }
  }
}
</script>

<style rel="stylesheet/scss" lang="scss">

.btn {
  color: #fff;
  text-transform: uppercase;
  background-color: #3C565B;
  margin-top: 20px;
  height: 50px;
  border: none;
  border-radius: 0;

  :active {
    background-color: gray;
  }

    :hover {
    background-color: gray;
  }
}

$bg: #f3f8f8;
$light_gray: #eee;
$cursor: #212121;
$dark_gray: #889aa4;

@supports (-webkit-mask: none) and (not (cater-color: $cursor)) {
  .login-container .el-input input {
    color: $dark_gray;
    &::first-line {
      color: $dark_gray;
    }
  }
}

.reset-info{
      margin: 0px auto 20px auto;
      text-align: center;
      color: $dark_gray;
}

/* reset element-ui css */
.login-container {
  .el-input {
    display: inline-block;
    height: 47px;
    width: 85%;
    input {
      background: transparent;
      border: 0px;
      -webkit-appearance: none;
      border-radius: 0px;
      padding: 12px 5px 12px 15px;
      color: $light_gray;
      height: 47px;
      caret-color: $cursor;
      &:-webkit-autofill {
        -webkit-box-shadow: 0 0 0px 1000px $bg inset !important;
        -webkit-text-fill-color: $cursor !important;
      }
    }
  }
  .el-form-item {
    border: 1px solid rgba(255, 255, 255, 0.1);
    background: rgba(0, 0, 0, 0.1);
    border-radius: 5px;
    color: #454545;
  }
}
</style>

<style rel="stylesheet/scss" lang="scss" scoped>
$bg: #f3f8f8;
$dark_gray: #889aa4;
$light_gray: #eee;

.login-container {
  position: fixed;
  height: 100%;
  width: 100%;
  background-color: $bg;
  .login-form {
    position: absolute;
    left: 0;
    right: 0;
    width: 520px;
    max-width: 100%;
    padding: 35px 35px 15px 35px;
    margin: 120px auto;
    border: 0.1px solid #e5e5e5;
    border-radius: 4px;
    box-shadow: 2px 2px 2px 2px rgba(0, 0, 0, 0.06);
    background-color: #fff;
  }
  .tips {
    font-size: 14px;
    color: $dark_gray;
    margin-bottom: 10px;
    span {
      &:first-of-type {
        margin-right: 16px;
      }
    }
  }
  .svg-container {
    padding: 6px 5px 6px 15px;
    color: $dark_gray;
    vertical-align: middle;
    width: 30px;
    display: inline-block;
  }
  .title-container {
    position: relative;
    .title {
      font-size: 26px;
      color: $dark_gray;
      margin: 0px auto 30px auto;
      text-align: center;
      font-weight: bold;
    }
    .logo{
      width: auto;
      height: 80px;
      display: block;
      margin-left: auto;
      margin-right: auto;
      padding-bottom: 20px;
      padding-left: 100px;
    }
  }
}
</style>

#! /bin/bash

function update_database() {
  read -p "Do you want to update to database? (Y/N) " yes_or_no
  case "$yes_or_no" in
    [yY] | [yY][eE][sS])
      echo "Updating to database ..."
      dotnet ef database update
      echo "Finished."
      ;;
    *)
      echo "Finished without updating database."
      ;;
  esac
}

read -p "Please enter a name of the migration: " name
if [ ! -n "$name"  ]; then
  echo "Error: the 'name' of the migration is required!"
else
  echo "Start migrating the database ..."
  dotnet ef migrations add $name -o Migrations && update_database
fi
